using Core.Entities;
using Core.Ioc.Repositories;
using Core.Ioc.Services;
using Core.Ioc.UnitOfWorks;

namespace Service.Services;

public class UserRefreshTokenService : GenericService<RefreshToken, int>, IRefreshTokenService
{
    public UserRefreshTokenService(IGenericRepository<RefreshToken, int> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}