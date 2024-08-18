using AutoServiceTracking.Shared.Dtos.Auth;
using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using AutoServiceTracking.Web.Dashboard.Infrastructure.ApiServices;
using AutoServiceTracking.Web.Dashboard.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceTracking.Web.Dashboard.Controllers
{
    public class ServiceEntryController : Controller
    {
        private readonly ServiceEntryService _serviceEntryService;

        public ServiceEntryController(ServiceEntryService serviceEntryService)
        {
            _serviceEntryService = serviceEntryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _serviceEntryService.GetServiceEntries();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateServiceEntry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceEntry(CreateServiceEntryDto dto)
        {
            try
            {
                var responseDto = await _serviceEntryService.AddServiceEntry(dto);
                ErrorHelper.ResponseHandler(responseDto, this.ControllerContext);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
