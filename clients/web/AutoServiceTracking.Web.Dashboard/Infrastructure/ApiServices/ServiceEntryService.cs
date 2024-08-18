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

    }
}
