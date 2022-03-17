using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Table;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class TableController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public TableController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _unitOfWorkService.tableService.GetAllPaginatedAsync(page));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TablePostVM tablePostVm)
        {
            if (ModelState.IsValid)
            {
                if (await _unitOfWorkService.tableService.IsExist(tablePostVm.TableNumber))
                {
                    ModelState.AddModelError("TableNumber", "This Table Number Already Exist");
                    return View(tablePostVm);
                }


                try
                {
                    await _unitOfWorkService.tableService.Create(tablePostVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(tablePostVm);
                }
                return RedirectToAction("Index");
            }

            return View(tablePostVm);
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id < 1) return NotFound();
            var table = await _unitOfWorkService.tableService.GetAsync(id);
            var tableVM = new TablePostVM
            {
                Id = table.Id ,// for check is exist
                TableNumber = table.TableNumber,
                MaxPersonCount = table.MaxPersonCount
            };


            return View(tableVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, TablePostVM tablePostVm)
        {
            if (id < 1) return NotFound();
            if (ModelState.IsValid)
            {
                // if (id!=tablePostVm.Id)
                // {
                //     if (await _unitOfWorkService.tableService.IsExist(tablePostVm.TableNumber))
                //     {
                //         ModelState.AddModelError("TableNumber", "This Table Number Already Exist");
                //         return View(tablePostVm);
                //     }
                // }
                try
                {
                    await _unitOfWorkService.tableService.Update(id, tablePostVm);
                    return RedirectToAction("Index", "Table");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("TableNumber", e.Message);
                    return View(tablePostVm);
                }
            }

            return null;

            // var product = await _unitOfWorkService.productService.GetAsync(id);
            // if (product == null) return NotFound();
            // ViewBag.categories = await _unitOfWorkService.productCategoryService.GetAllAsync();
            // return View(new ProductUpdateVM()
            // {
            //     Name = product.Name,
            //     Title = product.Title,
            //     Description = product.Title,
            //     ProductCategoryID = product.ProductCategoryID,
            //     Price = product.Price
            // });
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _unitOfWorkService.tableService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}