using Core.Entities;
using Core.Ioc.Repositories;
using Core.Ioc.Services;
using Core.Ioc.UnitOfWorks;

namespace Service.Services;

public class UserService : GenericService<User, int>, IUserService
{
    public UserService(IGenericRepository<User, int> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
