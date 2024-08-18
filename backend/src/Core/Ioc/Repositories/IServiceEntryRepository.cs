using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using AutoServiceTracking.Shared.Models;
using Core.Entities;

namespace Core.Ioc.Repositories;

public interface IServiceEntryRepository : IGenericRepository<ServiceEntry, int>
{
    Task<List<ServiceEntriesProcedureModel>> GetServiceEntriesByProcedureAsync();
}
