using Core.Entities;
using Core.Ioc.Repositories;
using Repositories;
using Repository.Contexts;

namespace Repository.Repositories;

public class UserRepository : GenericRepository<User, int>, IUserRepository
{
    public UserRepository(AutoServiceTrackingContext context) : base(context) { }
}
