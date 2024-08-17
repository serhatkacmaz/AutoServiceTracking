using Core.Entities;
using Core.Ioc.Repositories;
using Repositories;
using Repository.Contexts;

namespace Repository.Repositories;

public class ServiceEntryRepository : GenericRepository<ServiceEntry, int>, IServiceEntryRepository
{
    public ServiceEntryRepository(AutoServiceTrackingContext context) : base(context) { }
}