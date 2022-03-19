using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.DashBoard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public DashBoardController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index()
        {
            var reservs = await _unitOfWorkService
                .reservationService
                .GetAllAsync();
            var categories = await _unitOfWorkService
                .productCategoryService
                .GetAllAsync();
            var products = await _unitOfWorkService
                .productService
                .GetAllAsync();
            var tables = await _unitOfWorkService
                .tableService
                .GetAllAsync();
            var comments = await _unitOfWorkService
                .commentService
                .GetAllAsync();
            var contacts = await _unitOfWorkService
                .contactService
                .GetAllAsync();
            var gallery = await _unitOfWorkService
                .galleryService
                .GetAllAsync();
            var dashBoardVM = new DashBoardVM()
            {
                ActiveReservCount = reservs
                    .Where(p => p.IsActive == true)
                    .Count(),
                TodayReservCount = reservs
                    .Where(p => p.IsActive == true && p.ReservDate.Date == DateTime.Now.Date)
                    .Count(),
                CategoryCount = categories
                    .Count(),
                ProductCount = products
                    .Count(),
                TableCount = tables
                    .Count(),
                CommentCount = comments.Count,
                PendingContactCount = contacts
                    .Where(p => p.Status == false)
                    .Count(),
                ImageCount = gallery.Count
            };
            return View(dashBoardVM);
        }
    }
}