using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Table;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    public class TableController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public TableController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var Tables = await _unitOfWorkService.tableService.GetAllPaginatedAsync(page);
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
                if (await _unitOfWorkService.tableService.IsExist(tablePostVm.TableNumber))
                {
                    ModelState.AddModelError("TableNumber", "This Table Number Already Exist");
                    return View(tablePostVm);
                }


                await _unitOfWorkService.tableService.Create(tablePostVm);
                return RedirectToAction("Index");
            }

            return View(tablePostVm);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _unitOfWorkService.tableService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}