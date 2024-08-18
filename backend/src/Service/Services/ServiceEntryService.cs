using AutoMapper;
using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using Core.Entities;
using Core.Ioc.Repositories;
using Core.Ioc.Services;
using Core.Ioc.UnitOfWorks;

namespace Service.Services;

public class ServiceEntryService : GenericService<ServiceEntry, int>, IServiceEntryService
{
    IMapper _mapper;
    IServiceEntryRepository _serviceEntryRepository;

    public ServiceEntryService(IGenericRepository<ServiceEntry, int> repository, IUnitOfWork unitOfWork, IMapper mapper, IServiceEntryRepository serviceEntryRepository) : base(repository, unitOfWork)
    {
        _mapper = mapper;
        _serviceEntryRepository = serviceEntryRepository;
    }

    public async Task<IEnumerable<ServiceEntriesProcedureDto>> GetServiceEntriesByProcedureAsync()
    {
        var modelList = await _serviceEntryRepository.GetServiceEntriesByProcedureAsync();
        var dtoList = _mapper.Map<IEnumerable<ServiceEntriesProcedureDto>>(modelList);

        return dtoList;
    }
}
