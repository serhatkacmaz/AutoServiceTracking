using Core.Entities;
using Core.Ioc.Repositories;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repository.Contexts;

namespace Repository.Repositories;

public class UserRepository : GenericRepository<User, int>, IUserRepository
{
    public UserRepository(AutoServiceTrackingContext context) : base(context) { }

    public Task<User?> FindByMailAsync(string mail)
    {
        return context.Users
            .AsNoTracking()
            .Where(x => x.Email == mail)
            .SingleOrDefaultAsync();
    }
}
