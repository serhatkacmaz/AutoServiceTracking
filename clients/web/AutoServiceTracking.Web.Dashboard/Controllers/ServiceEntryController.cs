using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using AutoServiceTracking.Web.Dashboard.Infrastructure.ApiServices;
using AutoServiceTracking.Web.Dashboard.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoServiceTracking.Web.Dashboard.Controllers
{
    public class ServiceEntryController : BaseController
    {
        private readonly ServiceEntryService _serviceEntryService;
        private readonly CountriesNowService _countriesNowService;

        public ServiceEntryController(ServiceEntryService serviceEntryService, CountriesNowService countriesNowService)
        {
            _serviceEntryService = serviceEntryService;
            _countriesNowService = countriesNowService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _serviceEntryService.GetServiceEntries();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateServiceEntry()
        {
            await PopulateCityDropDownList();
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
                await PopulateCityDropDownList();
                return View();
            }
        }

        #region private methods
        private async Task PopulateCityDropDownList()
        {
            var itemList = new List<SelectListItem>();
            var cityList = await _countriesNowService.GetCities();

            itemList.AddRange(cityList.Select(x => new SelectListItem { Text = x, Value = x }));

            //TODO: Refactor cache...
            ViewBag.CityDropDownList = itemList;
        }

        #endregion
    }
}
