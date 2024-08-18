using AutoServiceTracking.Shared.Dtos.Auth;
using AutoServiceTracking.Web.Dashboard.Infrastructure.ApiServices;
using AutoServiceTracking.Web.Dashboard.Infrastructure.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace AutoServiceTracking.Web.Dashboard.Controllers
{
    public class AuthController : BaseController
    {
        private readonly AuthApiService _authApiService;

        public AuthController(AuthApiService authApiService)
        {
            _authApiService = authApiService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] SignInDto sigInDto)
        {
            var result = await _authApiService.CreateTokenAsync(sigInDto);

            if (result.Errors == null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(result.Data.AccessToken);

                Response.Cookies.Append(ApiConstants.AccessToken, result.Data.AccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = result.Data.AccessTokenExpiration
                });
                Response.Cookies.Append(ApiConstants.RefreshToken, result.Data.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = result.Data.RefreshTokenExpiration
                });

                return Json(new { isSuccess = true });
            }
            else
            {
                return Json(new { isSuccess = false, errorMessage = "Invalid username or password" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (Request.Cookies.TryGetValue(ApiConstants.RefreshToken, out var refreshToken))
            {
                await _authApiService.RevokeRefreshTokenAsync(new RefreshJwtDto { Token = refreshToken });
            }

            Response.Cookies.Delete(ApiConstants.AccessToken);
            Response.Cookies.Delete(ApiConstants.RefreshToken);

            HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Auth");
        }
    }
}
