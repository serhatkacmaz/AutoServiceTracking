using AutoServiceTracking.Shared.Security.Jwt;
using AutoServiceTracking.Shared.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoServiceTracking.Shared.Extensions;

public static class AuthRegistration
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        //-> Options
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        //-> Token Dogrulama
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
        {
            var tokenOptions = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidIssuer = tokenOptions.Issuer,
                ValidAudience = tokenOptions.Audience[0],
                IssuerSigningKey = SignHelper.GetSymmetricSecurityKey(tokenOptions.SecurityKey),

                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };
            opts.RequireHttpsMetadata = false;
            opts.SaveToken = true;
        });

        return services;
    }
}
