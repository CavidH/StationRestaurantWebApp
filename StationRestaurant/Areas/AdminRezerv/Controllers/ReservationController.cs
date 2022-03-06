using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}