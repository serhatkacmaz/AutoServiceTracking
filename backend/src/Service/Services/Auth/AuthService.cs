using AutoServiceTracking.Shared.Dtos.Auth;
using AutoServiceTracking.Shared.Security.Encryption;
using Core.Entities;
using Core.Ioc.Repositories;
using Core.Ioc.Services.Auth;
using Core.Ioc.UnitOfWorks;
using AutoServiceTracking.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace Service.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IAuthTokenService _authTokenService;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IAuthTokenService authTokenService, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, IUnitOfWork unitOfWork)
    {
        _authTokenService = authTokenService;
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RequestResponse<JwtDto>> CreateTokenAsync(SignInDto signInDto)
    {
        if (signInDto is null)
            throw new ArgumentNullException(nameof(signInDto));

        var user = await _userRepository.FindByMailAsync(signInDto.Email);

        if (user == null)
            return RequestResponse<JwtDto>.Fail(StatusCodes.Status400BadRequest, "Mail or Password is wrong");

        if (user.Password != signInDto.Password)
            return RequestResponse<JwtDto>.Fail(StatusCodes.Status400BadRequest, "Mail or Password is wrong");

        if (!user.Status)
            return RequestResponse<JwtDto>.Fail(StatusCodes.Status401Unauthorized, "User is not active");

        var jwtDto = _authTokenService.CreateToken(user);
        var refreshToken = await _refreshTokenRepository.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

        if (refreshToken is null)
        {
            await _refreshTokenRepository.AddAsync(new RefreshToken()
            {
                UserId = user.Id,
                Code = jwtDto.RefreshToken,
                Expiration = jwtDto.RefreshTokenExpiration
            });
        }
        else
        {
            refreshToken.Code = jwtDto.RefreshToken;
            refreshToken.Expiration = jwtDto.RefreshTokenExpiration;
        }

        await _unitOfWork.CommitAsync();
        return RequestResponse<JwtDto>.Success(StatusCodes.Status200OK, jwtDto);
    }

    public async Task<RequestResponse<JwtDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
    {
        var existRefreshToken = await _refreshTokenRepository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

        if (existRefreshToken is null)
            return RequestResponse<JwtDto>.Fail(StatusCodes.Status404NotFound, "Refresh token not found");

        var user = (await _userRepository.GetByIdAsync(existRefreshToken.UserId));

        if (user is null)
            return RequestResponse<JwtDto>.Fail(StatusCodes.Status404NotFound, "User not found");

        var jwtDto = _authTokenService.CreateToken(user);
        existRefreshToken.Code = jwtDto.RefreshToken;
        existRefreshToken.Expiration = jwtDto.RefreshTokenExpiration;

        await _unitOfWork.CommitAsync();
        return RequestResponse<JwtDto>.Success(StatusCodes.Status200OK, jwtDto);
    }

    public async Task<RequestResponse<NoContentData>> RevokeRefreshTokenAsync(string refreshToken)
    {
        var existRefreshToken = await _refreshTokenRepository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

        if (existRefreshToken is null)
            return RequestResponse<NoContentData>.Fail(StatusCodes.Status404NotFound, "Refresh token not found");

        _refreshTokenRepository.Remove(existRefreshToken);
        await _unitOfWork.CommitAsync();

        return RequestResponse<NoContentData>.Success(StatusCodes.Status200OK);
    }
}
