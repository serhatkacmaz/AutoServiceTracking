using Core.Entities;

namespace Core.Ioc.Repositories;

public interface IUserRepository : IGenericRepository<User, int>
{
    Task<User?> FindByMailAsync(string mail);
}
