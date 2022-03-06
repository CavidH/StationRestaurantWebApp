using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class ReservationController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}