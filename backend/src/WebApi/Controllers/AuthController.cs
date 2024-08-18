using AutoServiceTracking.Shared.Dtos.Auth;
using Core.Ioc.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
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
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshJwtDto refreshJwtDto)
        {
            return CreateActionResult(await _authService.CreateTokenByRefreshTokenAsync(refreshJwtDto.Token));
        }

        [HttpPost]
        [Route("RevokeRefreshToken")]
        public async Task<IActionResult> RevokeRefreshToken(RefreshJwtDto refreshJwtDto)
        {
            return CreateActionResult(await _authService.RevokeRefreshTokenAsync(refreshJwtDto.Token));
        }
    }
}
