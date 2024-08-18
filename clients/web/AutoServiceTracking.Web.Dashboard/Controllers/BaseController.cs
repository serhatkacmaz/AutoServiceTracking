using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoServiceTracking.Web.Dashboard.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
