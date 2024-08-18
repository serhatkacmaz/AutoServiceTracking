using AutoMapper;
using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using AutoServiceTracking.Shared.Responses;
using Core.Entities;
using Core.Ioc.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ServiceEntriesController : BaseController
{
    private readonly IServiceEntryService _serviceEntryService;
    private readonly IMapper _mapper;

    public ServiceEntriesController(IServiceEntryService serviceEntryService, IMapper mapper)
    {
        _serviceEntryService = serviceEntryService;
        _mapper = mapper;
    }

    [HttpGet("GetServiceEntries")]
    public async Task<IActionResult> GetServiceEntries()
    {
        var dtoList = await _serviceEntryService.GetServiceEntriesByProcedureAsync();
        return CreateActionResult(RequestResponse<IEnumerable<ServiceEntriesProcedureDto>>.Success(StatusCodes.Status200OK, dtoList));
    }

    [HttpPost("AddServiceEntry")]
    public async Task<IActionResult> AddServiceEntry([FromBody] CreateServiceEntryDto createServiceEntryDto)
    {
        var newEntity = _mapper.Map<ServiceEntry>(createServiceEntryDto);
        var createdNewEntity = await _serviceEntryService.AddAsync(newEntity);
        var createdNewEntityDto = _mapper.Map<CreatedServiceEntryDto>(createdNewEntity);

        return CreateActionResult(RequestResponse<CreatedServiceEntryDto>.Success(StatusCodes.Status200OK, createdNewEntityDto));
    }
}
