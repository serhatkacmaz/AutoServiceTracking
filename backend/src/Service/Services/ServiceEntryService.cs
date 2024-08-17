using Core.Entities;
using Core.Ioc.Repositories;
using Core.Ioc.Services;
using Core.Ioc.UnitOfWorks;

namespace Service.Services;

public class ServiceEntryService : GenericService<ServiceEntry, int>, IServiceEntryService
{
    public ServiceEntryService(IGenericRepository<ServiceEntry, int> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
