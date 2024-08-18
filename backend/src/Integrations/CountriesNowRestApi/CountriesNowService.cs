using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Integrations.CountriesNowRestApi;

public class CountriesNowService : ICountriesNowService
{
    private readonly HttpClient _httpClient;

    public CountriesNowService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<string>> GetCities()
    {
        var requestBody = new { country = "Turkey" };
        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://countriesnow.space/api/v0.1/countries/cities", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API request failed with status code {response.StatusCode}");
        }

        var responseString = await response.Content.ReadAsStringAsync();
        var responseData = JsonSerializer.Deserialize<CountriesNowApiResponse>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return responseData.Data;
    }
}