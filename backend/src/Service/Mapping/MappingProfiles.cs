using AutoMapper;
using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using AutoServiceTracking.Shared.Dtos.User;
using AutoServiceTracking.Shared.Models;
using Core.Entities;

namespace Service.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, CreatedUserDto>().ReverseMap();
        CreateMap<User, GetAllUserDto>();

        CreateMap<ServiceEntry, CreateServiceEntryDto>().ReverseMap();
        CreateMap<ServiceEntry, CreatedServiceEntryDto>().ReverseMap();
        CreateMap<ServiceEntry, GetListServiceEntryDto>();

        CreateMap<ServiceEntriesProcedureModel, ServiceEntriesProcedureDto>().ReverseMap();
    }
}
