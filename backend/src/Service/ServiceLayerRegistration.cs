using Core.Ioc.Repositories;
using Core.Ioc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repository.Contexts;
using Repository.Repositories;
using Service.Services;
using System.Reflection;

namespace Service;

public static class ServiceLayerRegistration
{
    public static IServiceCollection AddServiceLayerServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IServiceEntryService, ServiceEntryService>();

        return services;
    }
}