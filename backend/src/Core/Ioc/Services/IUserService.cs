using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using AutoServiceTracking.Shared.Models;
using Core.Entities;

namespace Core.Ioc.Services;

public interface IUserService : IGenericService<User, int>
{
}
