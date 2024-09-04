using Microsoft.AspNetCore.Mvc;

namespace TicketBus.Controllers
{
    public class RouteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
