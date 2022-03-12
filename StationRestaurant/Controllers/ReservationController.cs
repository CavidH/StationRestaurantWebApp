using System.Threading.Tasks;
using Business.Interfaces;
using Business.Utilities.Helpers;
using Business.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace StationRestaurant.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ITableService _tableService;
        private readonly IConfiguration _configuration;

        public ReservationController(IReservationService reservationService, ITableService tableService,IConfiguration configuration)
        {
            _reservationService = reservationService;
            _tableService = tableService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.tables = await _tableService.GetAllAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ReservationPostVM reservationPostVm)
        {
            ViewBag.tables = await _tableService.GetAllAsync();
            if (ModelState.IsValid)
            {
                if (await _reservationService.IsReserved(reservationPostVm.ReservDate.Date, reservationPostVm.TableID))
                {
                    ModelState.AddModelError("TableID", "This table has already been reserved");
                    return View(reservationPostVm);
                }

                await _reservationService.Create(reservationPostVm);
                 
                EmailHelper.EmailContentBuilder(reservationPostVm.Email, "ConfirmationLink", "Confirm Email");
                return RedirectToAction("Index", "Home");
            }

            return View(reservationPostVm);
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