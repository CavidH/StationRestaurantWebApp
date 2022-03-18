using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Gallery;
using Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class GalleryController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly AppDbContext _context;

        public GalleryController(IUnitOfWorkService unitOfWorkService, AppDbContext context)
        {
            _unitOfWorkService = unitOfWorkService;
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            //var c = await _context.GaleryImages.ToListAsync();

            return View(await _unitOfWorkService.galleryService.GetAllPaginatedAsync(page, 10));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GalleryPostVM galleryPostVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.galleryService.Create(galleryPostVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("ImageFiles", e.Message);
                    return View(galleryPostVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(galleryPostVm);
        }

        public ActionResult Update(int id)
        {
            if (id <= 0) return NotFound();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, GalleryUpdateVM galleryUpdateVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.galleryService.Update(id, galleryUpdateVm);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("ImagFile", e.Message);
                    return View(galleryUpdateVm);
                }
            }

            return View(galleryUpdateVm);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0) return NotFound();
            try
            {
                await _unitOfWorkService.galleryService.Remove(id);
            }
            catch (Exception e)
            {
            }

            return RedirectToAction(nameof(Index));
        }
    }
}