using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using Core.Entities;

namespace Core.Ioc.Services;

public interface IServiceEntryService : IGenericService<ServiceEntry, int>
{
    Task<IEnumerable<ServiceEntriesProcedureDto>> GetServiceEntriesByProcedureAsync();
}
