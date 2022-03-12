using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class AccountController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}