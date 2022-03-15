using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ReservationController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.tables = await _unitOfWorkService.tableService.GetAllAsync();
            return View(await _unitOfWorkService.reservationService.GetAllPaginatedAsync(page));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(Paginate<Reservation> paginate, int page = 1)
        {
            ViewBag.tables = await _unitOfWorkService.tableService.GetAllAsync();
            return View(await _unitOfWorkService.reservationService.GetAllPaginatedAsync(page, paginate.Item.ReservDate.Date));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _unitOfWorkService.reservationService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}