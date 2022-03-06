using System.Threading.Tasks;
using Business.Implementations;
using Business.Interfaces;
using Business.ViewModels.Table;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    public class TableController : Controller
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var Tables = await _tableService.GetAllPaginatedAsync(page);
            return View(Tables);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TablePostVM tablePostVm)
        {
            if (ModelState.IsValid)
            {
                if (await _tableService.IsExist(tablePostVm.TableNumber))
                {
                    ModelState.AddModelError("TableNumber", "This Table Number Already Exist");
                    return View(tablePostVm);
                }


                await _tableService.Create(tablePostVm);
                return RedirectToAction("Index");
            }

            return View(tablePostVm);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _tableService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}