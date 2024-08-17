using Core.Ioc.Services;
using Core.Ioc.Services.Auth;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Services.Auth;
using System.Reflection;

namespace Service;

public static class ServiceLayerRegistration
{
    public static IServiceCollection AddServiceLayerServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthTokenService, AuthTokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IServiceEntryService, ServiceEntryService>();
        services.AddScoped<IRefreshTokenService, UserRefreshTokenService>();

        return services;
    }
}