using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Utilities.Helpers;
using Business.ViewModels.Reservation;
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

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ReservationPostVM reservationPostVm)
        {
            ViewBag.tables = await _unitOfWorkService.tableService.GetAllAsync();
            if (ModelState.IsValid)
            {
                if (await _unitOfWorkService.reservationService.IsReserved(reservationPostVm.ReservDate.Date,
                        reservationPostVm.TableID))
                {
                    ModelState.AddModelError("TableID", "This table has already been reserved");
                    return View(reservationPostVm);
                }

                await _unitOfWorkService.reservationService.Create(reservationPostVm);
                var Id = await _unitOfWorkService.reservationService.getLastIdAsync();
                var confirmationLink = Url.Action("ConfirmReserv", "Reservation",
                    new {reservationId = Id, token = reservationPostVm.ReservDate}, Request.Scheme);
                EmailHelper.EmailContentBuilder(reservationPostVm.Email, confirmationLink, "Confirm Email");
                return RedirectToAction("Index", "Home");
            }

            return View(reservationPostVm);
        }

        public async Task<IActionResult> ConfirmReserv(int reservationId, string token)
        {
            var reservation = await _unitOfWorkService.reservationService.GetAsync(reservationId);
            if (reservation == null) return NotFound();
            if (reservation.IsActive)
            {
                ViewBag.msg = "Reservation Has Already Been Confirmed!";
                return View();
            }

            var tokenConfirmDt = reservation.ReservDate;
            var EmailDTToken = DateTime.ParseExact(token, "MM/dd/yyyy HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture);

            if (tokenConfirmDt == EmailDTToken)
            {
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


        // [HttpPost]
        // [AutoValidateAntiforgeryToken]
        // public async Task<IActionResult> Index(ReservationDataTimeVM reservationDataTimeVm)
        // {
        //     _emptyTables= await _reservationService.CheckRezervDate(reservationDataTimeVm.ReservDate);
        //      return RedirectToAction(nameof(Reservation));
        // }
        // [HttpGet]
        // public IActionResult RezervDate()
        // {
        //     return View();
        // }
        // [HttpPost]
        // [AutoValidateAntiforgeryToken]
        // public IActionResult RezervDate(ReservationPostVM reservationPostVm)
        // {
        //     return Json(reservationPostVm);
        //
        // }
        //

        // [HttpGet]
        // public IActionResult Reservation()
        // {
        //     ViewBag.tables = _emptyTables;
        //     return View();
        // }  
        // [HttpPost]
        // public IActionResult Reservation(ReservationPostVM  reservationPostVm)
        // {
        //    
        //     return View();
        // }
    }
}