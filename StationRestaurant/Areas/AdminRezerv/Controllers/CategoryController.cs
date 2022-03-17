using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.ProductCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
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
                try
                {
                    await _unitOfWorkService.productCategoryService.Create(productCategoryVm);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(productCategoryVm);
                }
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
                try
                {
                    await _unitOfWorkService.productCategoryService.Update(id, productCategoryVm);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(productCategoryVm);
                }
            }

            return View(productCategoryVm);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            try
            {
                await _unitOfWorkService.productCategoryService.Remove(id);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}