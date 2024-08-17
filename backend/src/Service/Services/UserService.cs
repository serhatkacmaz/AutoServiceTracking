using Core.Entities;
using Core.Ioc.Repositories;
using Core.Ioc.Services;
using Core.Ioc.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services;

public class UserService : GenericService<User, int>, IUserService
{
    public UserService(IGenericRepository<User, int> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
