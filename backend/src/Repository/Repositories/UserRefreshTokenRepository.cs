using Core.Entities;
using Core.Ioc.Repositories;
using Repositories;
using Repository.Contexts;

namespace Repository.Repositories;

public class UserRefreshTokenRepository : GenericRepository<RefreshToken, int>, IRefreshTokenRepository
{
    public UserRefreshTokenRepository(AutoServiceTrackingContext context) : base(context) { }
}
