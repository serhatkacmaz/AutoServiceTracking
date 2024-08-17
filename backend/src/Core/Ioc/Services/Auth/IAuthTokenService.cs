using AutoServiceTracking.Shared.Dtos.Auth;
using Core.Entities;

namespace Core.Ioc.Services.Auth;

public interface IAuthTokenService
{
    JwtDto CreateToken(User user);
}
