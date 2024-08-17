using AutoServiceTracking.Shared.Dtos.Auth;
using AutoServiceTracking.Shared.Security.Jwt;
using AutoServiceTracking.Shared.Settings;
using Core.Entities;
using Core.Ioc.Services.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Service.Services.Auth;

public class AuthTokenService : IAuthTokenService
{
    private readonly JwtSettings _jwtSettings;

    public AuthTokenService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public JwtDto CreateToken(User user)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpiration);
        var refreshTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.RefreshTokenExpiration);

        var securityKey = SignHelper.GetSymmetricSecurityKey(_jwtSettings.SecurityKey);
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
            expires: accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: GetClaims(user, _jwtSettings.Audience).Result,
            signingCredentials: signingCredentials);

        var handler = new JwtSecurityTokenHandler();
        var token = handler.WriteToken(jwtSecurityToken);

        var jwtDto = new JwtDto()
        {
            AccessToken = token,
            RefreshToken = CreateRefreshToken(),
            AccessTokenExpiration = accessTokenExpiration,
            RefreshTokenExpiration = refreshTokenExpiration
        };

        return jwtDto;
    }

    private async Task<IEnumerable<Claim>> GetClaims(User user, List<string> Audiences)
    {
        var claimList = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,user.FirstName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };

        claimList.AddRange(Audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
        return claimList;
    }

    private string CreateRefreshToken()
    {
        var numberByte = new Byte[32];
        using var rnd = RandomNumberGenerator.Create();
        rnd.GetBytes(numberByte);

        return Convert.ToBase64String(numberByte);
    }
}
