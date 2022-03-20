using System;
using System.Globalization;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Utilities.Helpers;
using Business.ViewModels.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ReservationController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.tables = await _unitOfWorkService.tableService.GetAllAsync();
            ViewBag.setting = await _unitOfWorkService.settingService.GetAllAsynDic();
            ViewBag.TimeIntervals = await _unitOfWorkService.timeIntervalService.GetAllAsync();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ReservationPostVM reservationPostVm)
        {
            ViewBag.tables = await _unitOfWorkService.tableService.GetAllAsync();
            ViewBag.TimeIntervals = await _unitOfWorkService.timeIntervalService.GetAllAsync();
            ViewBag.setting = await _unitOfWorkService.settingService.GetAllAsynDic();

            if (ModelState.IsValid)
            {
                var time = (await _unitOfWorkService.timeIntervalService.GetAsync(reservationPostVm.TimeIntervalIdId))
                    .Time;
                var endTime = reservationPostVm.ReservDate.AddHours(time);
                if (await _unitOfWorkService.reservationService.IsReserved(reservationPostVm.ReservDate,
                        endTime, reservationPostVm.TableID))
                {
                    ModelState.AddModelError("TableID", "This table has already been reserved");
                    return View(reservationPostVm);
                }

                await _unitOfWorkService.reservationService.Create(reservationPostVm);
                var Id = await _unitOfWorkService.reservationService.getLastIdAsync();
                var confirmationLink = Url.Action("ConfirmReserv", "Reservation",
                    new {reservationId = Id, token = reservationPostVm.ReservDate}, Request.Scheme);
                EmailHelper.EmailContentBuilder(reservationPostVm.Email, confirmationLink, "Confirm Reservation");
                return RedirectToAction("Index", "Home");
            }

            return View(reservationPostVm);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmReserv(int reservationId, string token)
        {
            var reservation = await _unitOfWorkService.reservationService.GetAsync(reservationId);
            if (reservation == null) return NotFound();


            var tokenConfirmDt = reservation.ReservDate;
            // var EmailDTToken = DateTime.ParseExact(token, "MM/dd/yyyy HH:mm:ss",
            //     System.Globalization.CultureInfo.InvariantCulture);
            DateTime EmailDTToken = DateTime.Now;
            try
            {
                EmailDTToken = DateTime.ParseExact(token, "MM/dd/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                EmailDTToken.AddYears(9);
            }

            if (tokenConfirmDt == EmailDTToken)
            {
                if (reservation.IsActive)
                {
                    ViewBag.msg = "Reservation Has Already Been Confirmed!";
                    return View();
                }

                try
                {
                    await _unitOfWorkService.reservationService.ConfirmReservation(reservation.Id);
                    ViewBag.msg = "Reservation Confirmed!";
                    return View();
                }
                catch (Exception e)
                {
                }
            }

            ViewBag.msg = "Reservation is Not Available!";

            return View();
        }
    }
}