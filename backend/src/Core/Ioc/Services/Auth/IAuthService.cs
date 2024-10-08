﻿using AutoServiceTracking.Shared.Dtos.Auth;
using AutoServiceTracking.Shared.Responses;

namespace Core.Ioc.Services.Auth;

public interface IAuthService
{
    Task<RequestResponse<JwtDto>> CreateTokenAsync(SignInDto signInDto);
    Task<RequestResponse<JwtDto>> CreateTokenByRefreshTokenAsync(string refreshToken);
    Task<RequestResponse<NoContentData>> RevokeRefreshTokenAsync(string refreshToken);
}
