using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using AutoServiceTracking.Shared.Responses;
using AutoServiceTracking.Web.Dashboard.Infrastructure.Constants;
using System.Net.Http.Headers;

namespace AutoServiceTracking.Web.Dashboard.Infrastructure.ApiServices
{
    public class ServiceEntryService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ServiceEntryService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;

            //TODO: Refactor
            var token = _httpContextAccessor.HttpContext?.Request.Cookies[ApiConstants.AccessToken];
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<RequestResponse<CreateServiceEntryDto>> AddServiceEntry(CreateServiceEntryDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("ServiceEntries/AddServiceEntry", dto);
            return await response.Content.ReadFromJsonAsync<RequestResponse<CreateServiceEntryDto>>();
        }

        public async Task<List<ServiceEntriesProcedureDto>> GetServiceEntries()
        {
            var response = await _httpClient.GetFromJsonAsync<RequestResponse<List<ServiceEntriesProcedureDto>>>("ServiceEntries/GetServiceEntries");
            return response.Data;
        }
    }
}
