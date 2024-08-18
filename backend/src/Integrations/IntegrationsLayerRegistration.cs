using Integrations.CountriesNowRestApi;
using Microsoft.Extensions.DependencyInjection;

namespace Integrations;

public static class IntegrationsLayerRegistration
{
    public static IServiceCollection AddIntegrationsLayerServices(this IServiceCollection services)
    {
        services.AddHttpClient<ICountriesNowService, CountriesNowService>();

        return services;
    }
}
