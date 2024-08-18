using AutoServiceTracking.Shared.Dtos.Auth;
using AutoServiceTracking.Web.Dashboard.Infrastructure.ApiServices;
using AutoServiceTracking.Web.Dashboard.Infrastructure.Constants;

namespace AutoServiceTracking.Web.Dashboard.Infrastructure.Middlewares;

public class AuthTokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AuthApiService _authApiService;

    public AuthTokenMiddleware(RequestDelegate next, AuthApiService authApiService)
    {
        _next = next;
        _authApiService = authApiService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var accessToken = context.Request.Cookies[ApiConstants.AccessToken];
        var refreshToken = context.Request.Cookies[ApiConstants.RefreshToken];

        if (!string.IsNullOrEmpty(accessToken))
        {
            context.Request.Headers.Add("Authorization", $"Bearer {accessToken}");
        }
        else
        {
            if (!string.IsNullOrEmpty(refreshToken))
            {
                var refreshResult = await _authApiService.CreateTokenByRefreshTokenAsync(new RefreshJwtDto() { Token = refreshToken });

                if (refreshResult.Errors is null)
                {
                    context.Response.Cookies.Append(ApiConstants.AccessToken, refreshResult.Data.AccessToken, new CookieOptions
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = refreshResult.Data.AccessTokenExpiration
                    });

                    context.Response.Cookies.Append(ApiConstants.RefreshToken, refreshResult.Data.RefreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = refreshResult.Data.RefreshTokenExpiration
                    });

                    context.Request.Headers.Add("Authorization", $"Bearer {refreshResult.Data.AccessToken}");
                }
            }
            else
            {
                //context.User = null;
                //context.Response.Redirect("/Home/Index");
                //return;
            }
        }

        await _next(context);
    }
}
