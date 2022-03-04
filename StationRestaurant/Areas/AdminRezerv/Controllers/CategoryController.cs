using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    public class CategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

        public CategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productCategoryService.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategoryVM productCategoryVm)
        {
            if (ModelState.IsValid)
            {
                await _productCategoryService.Create(productCategoryVm);
                return RedirectToAction(nameof(Index));
            }

            return View(productCategoryVm);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _productCategoryService.GetAsync(id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductCategoryVM productCategoryVm)
        {
            await _productCategoryService.Create(productCategoryVm);
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> Delete(int id)
        {
            await _productCategoryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
