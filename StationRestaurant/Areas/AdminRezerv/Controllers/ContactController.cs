using System;
using System.Threading.Tasks;
using Business.Interfaces;
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
            var contacts = await _unitOfWorkService
                .contactService
                .GetAllPaginatedAsync(page);
            return View(contacts);
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