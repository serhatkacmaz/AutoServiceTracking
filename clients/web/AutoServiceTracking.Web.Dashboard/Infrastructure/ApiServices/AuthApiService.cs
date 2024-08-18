using AutoServiceTracking.Shared.Dtos.Auth;
using AutoServiceTracking.Shared.Responses;
using AutoServiceTracking.Web.Dashboard.Infrastructure.Constants;
using System.Net.Http.Headers;

namespace AutoServiceTracking.Web.Dashboard.Infrastructure.ApiServices;

public class AuthApiService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public AuthApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;

        //TODO: Refactor
        var token = _httpContextAccessor.HttpContext?.Request.Cookies[ApiConstants.AccessToken];
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<RequestResponse<JwtDto>> CreateTokenAsync(SignInDto signInDto)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/CreateToken", signInDto);
        return await response.Content.ReadFromJsonAsync<RequestResponse<JwtDto>>();
    }

    public async Task<RequestResponse<JwtDto>> CreateTokenByRefreshTokenAsync(RefreshJwtDto refreshJwtDto)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/CreateTokenByRefreshToken", refreshJwtDto);
        return await response.Content.ReadFromJsonAsync<RequestResponse<JwtDto>>();
    }

    public async Task<RequestResponse<NoContentData>> RevokeRefreshTokenAsync(RefreshJwtDto refreshJwtDto)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/RevokeRefreshToken", refreshJwtDto);
        return await response.Content.ReadFromJsonAsync<RequestResponse<NoContentData>>();
    }
}
