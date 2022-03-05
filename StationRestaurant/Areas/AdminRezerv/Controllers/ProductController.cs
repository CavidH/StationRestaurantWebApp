using System.Threading.Tasks;
using Business.Interfaces;
using Business.Utilities;
using Business.ViewModels.ProductVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var products = await _productService.GetAllPaginatedAsync(page);
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _productCategoryService.GetAllAsync();
            var result = new ProductPostVM() {ProductCategories = categories};
            return View(result);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ProductPostVM productPostVm)
        {
            // if (ModelState["Image"].ValidationState == ModelValidationState.Invalid) return View();
            // productPostVm.ProductCategories = await _productCategoryService.GetAllAsync();
           
            if (ModelState.IsValid)
            {
                if (!productPostVm.ImageFile.CheckFileType("image/"))
                {
                    ModelState.AddModelError("ImageFile", "file  should be  image type ");
                    return View(productPostVm);
                }
            
                if (!productPostVm.ImageFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("ImageFile", "file size must be less than 200kb");
                    return View(productPostVm);
                }
                await _productService.Create(productPostVm);
                return RedirectToAction(nameof(Index));

            }
                // check error
            return RedirectToAction(nameof(Create));
            // return View(productPostVm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _productService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}