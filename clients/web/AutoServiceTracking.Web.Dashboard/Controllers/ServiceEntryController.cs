using Microsoft.AspNetCore.Mvc;

namespace AutoServiceTracking.Web.Dashboard.Controllers
{
    public class ServiceEntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
