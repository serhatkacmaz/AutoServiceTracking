using AutoServiceTracking.Shared.Responses;
using Integrations.CountriesNowRestApi;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CountriesNowController : BaseController
{
    ICountriesNowService _countriesNowService;

    public CountriesNowController(ICountriesNowService countriesNowService)
    {
        _countriesNowService = countriesNowService;
    }

    [HttpGet("Cities")]
    public async Task<IActionResult> Cities()
    {
        var cities = await _countriesNowService.GetCities();
        return CreateActionResult(RequestResponse<IEnumerable<string>>.Success(StatusCodes.Status200OK, cities));
    }
}
