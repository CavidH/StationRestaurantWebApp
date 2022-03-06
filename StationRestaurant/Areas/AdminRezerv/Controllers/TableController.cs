using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
