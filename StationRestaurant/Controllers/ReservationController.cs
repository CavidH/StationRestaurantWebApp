using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Reservation;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
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