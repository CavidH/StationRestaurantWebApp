using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Home;
using Business.ViewModels.Menu;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class MenuController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public MenuController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _unitOfWorkService.productCategoryService.GetAllAsync();
            var products = await _unitOfWorkService.productService.GetAllAsync();
            var HomeVM = new MenuVM
            {
                Products = products,
                ProductCategories = categories
            };
            return View(HomeVM);
        }
    }
}