using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
