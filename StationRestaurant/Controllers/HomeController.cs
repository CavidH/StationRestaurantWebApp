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
            var lastProducts = await _unitOfWorkService.productService.GetLastProductsAsync();
            var miniGallery = await _unitOfWorkService.galleryService.GetLastProductsAsync();
            var setting = await _unitOfWorkService.settingService.GetAllAsynDic();
            var about = await _unitOfWorkService.aboutService.GetAsync();


            var homeVM = new HomeVM
            {
                HeadSlides = slides,
                Products = lastProducts,
                MiniGallery = miniGallery,
                Settings = setting,
                About = about
            };
            return View(homeVM);
        }
    }
}