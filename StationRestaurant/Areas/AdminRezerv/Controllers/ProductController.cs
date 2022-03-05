﻿using System.Threading.Tasks;
using Business.Interfaces;
using Business.Utilities;
using Business.Validators.Product;
using Business.ViewModels.ProductVM;
using Microsoft.AspNetCore.Mvc;

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
            ViewBag.categories = await _productCategoryService.GetAllAsync();

            // var categories = await _productCategoryService.GetAllAsync();
            // var result = new ProductPostVM() {ProductCategories = categories};
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ProductPostVM productPostVm)
        {
            // if (ModelState["Image"].ValidationState == ModelValidationState.Invalid) return View();
            // productPostVm.ProductCategories = await _productCategoryService.GetAllAsync();
            ViewBag.categories = await _productCategoryService.GetAllAsync();

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
            // return RedirectToAction(nameof(Create));
            return View(productPostVm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id < 1) return BadRequest();
            var product = await _productService.GetAsync(id);
            if (product == null) return NotFound();
            ViewBag.categories = await _productCategoryService.GetAllAsync();
            return View(new ProductUpdateVM()
            {
                Name = product.Name,
                Title = product.Title,
                Description = product.Title,
                ProductCategoryID = product.ProductCategoryID
            });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id,ProductUpdateVM productUpdateVm)
        {
            // ViewBag.categories = await _productCategoryService.GetAllAsync();

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

                await _productService.Update(id,productUpdateVm);

                return RedirectToAction(nameof(Index));
            }

            return View(productUpdateVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _productService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}