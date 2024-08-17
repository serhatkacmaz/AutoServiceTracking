using Core.Entities;

namespace Core.Ioc.Repositories;

public interface IRefreshTokenRepository : IGenericRepository<RefreshToken, int>
{
}