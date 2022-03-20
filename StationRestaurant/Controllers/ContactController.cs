using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class ContactController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ContactController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactVM contactVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.contactService.Create(contactVm);
                    TempData["msg"] = "message sent";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    return View(contactVm);
                }
            }

            return View(contactVm);
        }
    }
}