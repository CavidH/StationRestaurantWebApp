using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.HeadSlide;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    public class HeadSlideController : Controller
    {
        private readonly IHeadSlideService _slideService;

        public HeadSlideController(IHeadSlideService slideService)
        {
            _slideService = slideService;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _slideService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        // [RequestSizeLimit(737280000)] for file size exeption jsjs
        public async Task<IActionResult> Create(HeadSlidePostVM headSlidePostVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _slideService.Create(headSlidePostVm);
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
        public async Task<IActionResult> Update(int Id, HeadSlideUpdateVM headSlideUpdateVm)
        {
            if (Id == 0) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _slideService.Update(Id, headSlideUpdateVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("ImageFile",e.Message);
                    return View(headSlideUpdateVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(headSlideUpdateVm);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0) return NotFound();
            try
            {
                await _slideService.Remove(Id);
            }
            catch (Exception e)
            {
            }

            return RedirectToAction(nameof(Index));
        }
    }
}