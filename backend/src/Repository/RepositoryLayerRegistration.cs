using Core.Ioc.Repositories;
using Core.Ioc.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repository.Contexts;
using Repository.Repositories;
using Repository.UnitOfWorks;

namespace Repository;

public static class RepositoryLayerRegistration
{
    public static IServiceCollection AddRepositoryLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AutoServiceTrackingContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AutoServiceTrackingDb"));
        });

        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IServiceEntryRepository, ServiceEntryRepository>();
        services.AddScoped<IRefreshTokenRepository, UserRefreshTokenRepository>();

        return services;
    }
}