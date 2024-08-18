using AutoMapper;
using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using Core.Entities;
using Core.Ioc.Services;
using AutoServiceTracking.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var entityList = await _serviceEntryService.GetAllAsync();
            var dtoList = _mapper.Map<IEnumerable<GetAllServiceEntryDto>>(entityList);

            return CreateActionResult(RequestResponse<IEnumerable<GetAllServiceEntryDto>>.Success(StatusCodes.Status200OK, dtoList));
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
}
