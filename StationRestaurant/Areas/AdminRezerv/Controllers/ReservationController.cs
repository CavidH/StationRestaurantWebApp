using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ITableService _tableService;

        public ReservationController(IReservationService reservationService, ITableService tableService)
        {
            _reservationService = reservationService;
            _tableService = tableService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.tables = await _tableService.GetAllAsync();
            return View(await _reservationService.GetAllPaginatedAsync(page));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(Paginate<Reservation> paginate, int page = 1)
        {
            ViewBag.tables = await _tableService.GetAllAsync();
            return View(await _reservationService.GetAllPaginatedAsync(page, paginate.Item.ReservDate.Date));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _reservationService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}