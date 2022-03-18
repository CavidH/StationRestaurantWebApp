using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public AboutController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWorkService.aboutService.GetAsync());
        }

        public async Task<IActionResult> Update()
        {
            var dbAbout = await _unitOfWorkService.aboutService.GetAsync();
            var aboutVM = new AboutVM()
            {
                Head = dbAbout.Head,
                Content = dbAbout.Content,
                Image = dbAbout.Image,
                Title = dbAbout.Title,
                UpdatedAt = dbAbout.UpdatedAt
            };
            return View(aboutVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutVM aboutVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.aboutService.Update(aboutVm);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(aboutVm);
                }
            }

            return View(aboutVm);
        }
    }
}