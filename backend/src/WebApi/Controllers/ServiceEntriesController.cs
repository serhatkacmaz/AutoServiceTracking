using AutoMapper;
using Core.Dtos.User;
using Core.Dtos;
using Core.Entities;
using Core.Ioc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Dtos.ServiceEntry;

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

            return CreateActionResult(ResponseDto<IEnumerable<GetAllServiceEntryDto>>.Success(StatusCodes.Status200OK, dtoList));
        }

        [HttpPost("AddServiceEntry")]
        public async Task<IActionResult> AddServiceEntry([FromBody] CreateServiceEntryDto createServiceEntryDto)
        {
            var newEntity = _mapper.Map<ServiceEntry>(createServiceEntryDto);
            var createdNewEntity = await _serviceEntryService.AddAsync(newEntity);
            var createdNewEntityDto = _mapper.Map<CreatedServiceEntryDto>(createdNewEntity);

            return CreateActionResult(ResponseDto<CreatedServiceEntryDto>.Success(StatusCodes.Status200OK, createdNewEntityDto));
        }
    }
}
