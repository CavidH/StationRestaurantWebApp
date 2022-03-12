using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public AccountController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserPostVM userPostVm)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkService.userService.Create(userPostVm);
                return RedirectToAction("Index", "Home");
            }

            return View(userPostVm);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginVM loginVm, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkService.userService.Login(loginVm);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }

                return RedirectToAction("Index", "DashBoard");
            }

            return View(loginVm);
        }
        public async Task<IActionResult> LogOut()
        {
            await _unitOfWorkService.userService.LogOut();
            return RedirectToAction("Index","Home");
        }
    }
}