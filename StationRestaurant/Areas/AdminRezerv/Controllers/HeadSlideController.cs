using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.HeadSlide;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class HeadSlideController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public HeadSlideController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWorkService.headSlideService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [RequestSizeLimit(737280000)] for file size exeption jsjs
        public async Task<IActionResult> Create(HeadSlidePostVM headSlidePostVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.headSlideService.Create(headSlidePostVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("FormFiles", e.Message);
                    return View(headSlidePostVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(headSlidePostVm);
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (Id == 0) return NotFound();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, HeadSlideUpdateVM headSlideUpdateVm)
        {
            if (Id == 0) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWorkService.headSlideService.Update(Id, headSlideUpdateVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("ImageFile", e.Message);
                    return View(headSlideUpdateVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(headSlideUpdateVm);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return NotFound();
            try
            {
                await _unitOfWorkService.headSlideService.Remove(Id);
            }
            catch (Exception e)
            {
            }

            return RedirectToAction(nameof(Index));
        }
    }
}