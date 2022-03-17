using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Utilities;
using Business.ViewModels.ProductVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ProductController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _unitOfWorkService.productService.GetAllPaginatedAsync(page));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await _unitOfWorkService.productCategoryService.GetAllAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ProductPostVM productPostVm)
        {
            ViewBag.categories = await _unitOfWorkService.productCategoryService.GetAllAsync();
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

                try
                {
                    await _unitOfWorkService.productService.Create(productPostVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(productPostVm);
                }

                return RedirectToAction(nameof(Index));
            }

            // check error
            // return RedirectToAction(nameof(Create));
            return View(productPostVm);
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id < 0) return BadRequest();
            var product = await _unitOfWorkService.productService.GetAsync(id);
            if (product == null) return NotFound();
            ViewBag.categories = await _unitOfWorkService.productCategoryService.GetAllAsync();
            return View(new ProductUpdateVM()
            {
                Name = product.Name,
                Title = product.Title,
                Description = product.Title,
                ProductCategoryID = product.ProductCategoryID,
                Price = product.Price
            });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, ProductUpdateVM productUpdateVm)
        {
            ViewBag.categories = await _unitOfWorkService.productCategoryService.GetAllAsync();

            if (ModelState.IsValid)
            {
                if (productUpdateVm.ImageFile != null)
                {
                    if (!productUpdateVm.ImageFile.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("ImageFile", "file  should be  image type ");
                        return View(productUpdateVm);
                    }

                    if (!productUpdateVm.ImageFile.CheckFileSize(300))
                    {
                        ModelState.AddModelError("ImageFile", "file size must be less than 200kb");
                        return View(productUpdateVm);
                    }
                }

                try
                {
                    await _unitOfWorkService.productService.Update(id, productUpdateVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(productUpdateVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(productUpdateVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            try
            {
                await _unitOfWorkService.productService.Remove(id);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}