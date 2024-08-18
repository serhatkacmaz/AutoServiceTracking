using AutoServiceTracking.Shared.Dtos.Auth;
using AutoServiceTracking.Shared.Responses;

namespace AutoServiceTracking.Web.Dashboard.Infrastructure.ApiServices;

public class AuthApiService
{
    private readonly HttpClient _httpClient;

    public AuthApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
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
