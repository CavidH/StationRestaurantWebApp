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
        // [RequestSizeLimit(737280000)] for file siz exeption jsjs

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
                    ModelState.AddModelError("ImageFile",e.Message);
                    return View(headSlidePostVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(headSlidePostVm);
        }
    }
}