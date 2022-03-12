using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace StationRestaurant.Controllers
{
    public class HomeController : Controller
    {
        // private readonly IHeadSlideService _headSlideService;
        // private readonly IP _headSlideService;

        private readonly IUnitOfWorkService _unitOfWorkService;
        public HomeController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index()
        {
            var slides = await _unitOfWorkService.headSlideService.GetAllAsync();

            var homeVM = new HomeVM
            {
                HeadSlides = slides
            };
            return View(homeVM);
        }
    }
}