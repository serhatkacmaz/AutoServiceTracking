using AutoMapper;
using Core.Dtos.ServiceEntry;
using Core.Dtos.User;
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
        CreateMap<ServiceEntry, GetAllServiceEntryDto>();
    }
}
