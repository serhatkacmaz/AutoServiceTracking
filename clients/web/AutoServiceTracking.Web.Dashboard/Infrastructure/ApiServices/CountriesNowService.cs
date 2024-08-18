using AutoServiceTracking.Shared.Responses;
using AutoServiceTracking.Web.Dashboard.Infrastructure.Constants;
using System.Net.Http.Headers;

namespace AutoServiceTracking.Web.Dashboard.Infrastructure.ApiServices;

public class CountriesNowService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CountriesNowService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;

        //TODO: Refactor
        var token = _httpContextAccessor.HttpContext?.Request.Cookies[ApiConstants.AccessToken];
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<List<string>> GetCities()
    {
        var response = await _httpClient.GetFromJsonAsync<RequestResponse<List<string>>>("CountriesNow/Cities");
        return response.Data;
    }
}
