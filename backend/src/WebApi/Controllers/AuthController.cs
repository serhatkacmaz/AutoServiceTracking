using AutoServiceTracking.Shared.Dtos.Auth;
using Core.Ioc.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("CreateToken")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateToken(SignInDto signInDto)
        {
            return CreateActionResult(await _authService.CreateTokenAsync(signInDto));
        }

        [HttpPost]
        [Route("CreateTokenByRefreshToken")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            return CreateActionResult(await _authService.CreateTokenByRefreshTokenAsync(refreshTokenDto.Token));
        }

        [HttpPost]
        [Route("RevokeRefreshToken")]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            return CreateActionResult(await _authService.RevokeRefreshTokenAsync(refreshTokenDto.Token));
        }
    }
}
