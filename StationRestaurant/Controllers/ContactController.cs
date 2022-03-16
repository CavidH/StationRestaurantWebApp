using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
