using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public CategoryController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWorkService.productCategoryService.GetAllAsync());
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
                await _unitOfWorkService.productCategoryService.Create(productCategoryVm);
                return RedirectToAction(nameof(Index));
            }

            return View(productCategoryVm);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id < 1) return BadRequest();
            //if (!await _productCategoryService.IsExits(id)) return NotFound();
            var category = await _unitOfWorkService.productCategoryService.GetAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProductCategoryVM productCategoryVm)
        {
            if (id < 1) return BadRequest();
            if (ModelState.IsValid)
            {
                //if (!await _productCategoryService.IsExits(id)) return NotFound();
                var category = await _unitOfWorkService.productCategoryService.GetAsync(id);
                if (category == null) return NotFound();
                await _unitOfWorkService.productCategoryService.Update(id, productCategoryVm);
                return RedirectToAction(nameof(Index));
            }

            return View(productCategoryVm);
        }




        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _unitOfWorkService.productCategoryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
