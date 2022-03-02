using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    public class CategoryController : Controller
    {
        [Area("AdminRezerv")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
