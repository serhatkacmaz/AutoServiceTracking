using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using AutoServiceTracking.Shared.Responses;

namespace AutoServiceTracking.Web.Dashboard.Infrastructure.ApiServices
{
    public class ServiceEntryService
    {
        private readonly HttpClient _httpClient;

        public ServiceEntryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RequestResponse<CreateServiceEntryDto>> AddServiceEntry(CreateServiceEntryDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("ServiceEntries/AddServiceEntry", dto);
            return await response.Content.ReadFromJsonAsync<RequestResponse<CreateServiceEntryDto>>();
        }
    }
}
