using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceTracking.Web.Dashboard.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
