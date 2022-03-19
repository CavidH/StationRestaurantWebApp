using System;
using Business.Interfaces;
using Business.ViewModels.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public MessageController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MessageVM messageVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWorkService.messageService.SendMessage(messageVm);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    return RedirectToAction(nameof(Index));
                    throw;
                }
            }

            return View(messageVm);
        }
    }
}