using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ITableService _tableService;

        public ReservationController(IReservationService reservationService, ITableService tableService)
        {
            _reservationService = reservationService;
            _tableService = tableService;
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