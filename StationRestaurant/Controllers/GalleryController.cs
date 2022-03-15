using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public GalleryController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _unitOfWorkService.galleryService.GetAllPaginatedAsync(page,12));
        }
    }
}