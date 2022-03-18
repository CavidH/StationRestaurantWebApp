using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Reply;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ContactController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _unitOfWorkService.contactService.GetAllPaginatedAsync(page));
        }

        public async Task<IActionResult> Reply(int id)
        {
            if (id < 1) NotFound();
            try
            {
                var contact = await _unitOfWorkService.contactService.GetAsync(id);
                var replyVM = new ReplyVM
                {
                    Contact = contact
                };
                return View(replyVM);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
            //reply yaz email config ele davam to do da
        }

        [HttpPost]
        public async Task<IActionResult> Reply(int id, ReplyVM replyVm)
        {
            if (id < 1) NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.contactService.ReplyAsync(id, replyVm);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            var contact = await _unitOfWorkService.contactService.GetAsync(id);
            replyVm.Contact = contact;
            return View(replyVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _unitOfWorkService.contactService.Remove(id);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}