using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
