using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Setting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class SettingController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public SettingController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index()
        {
            // var hh = settings.ToDictionary(p => p.Key, p => p.Value);
            // var plan = hh["plan"];
            return View(await _unitOfWorkService.settingService.GetAllAsync());
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id < 1) return NotFound();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SettingVM settingVm)
        {
            if (id < 1) return NotFound();
            if (ModelState.IsValid)
            {
                
                try
                {
                    await _unitOfWorkService.settingService.Update(id, settingVm);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("ImageFile", e.Message);
                    return View(settingVm);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}