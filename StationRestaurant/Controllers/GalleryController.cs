using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
