using AutoMapper;
using AutoServiceTracking.Shared.Dtos.User;
using Core.Entities;
using Core.Ioc.Services;
using AutoServiceTracking.Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet("Users")]
    public async Task<IActionResult> Users()
    {
        var users = await _userService.GetAllAsync();
        var dtoList = _mapper.Map<IEnumerable<GetAllUserDto>>(users);

        return CreateActionResult(RequestResponse<IEnumerable<GetAllUserDto>>.Success(StatusCodes.Status200OK, dtoList));
    }

    [HttpPost("NewUser")]
    public async Task<IActionResult> NewUser([FromBody] CreateUserDto createUserDto)
    {
        //Şifreyi Hashle
        //Seed'dakinde sıkıntı var...
        var newUser = _mapper.Map<User>(createUserDto);
        var createdNewUser = await _userService.AddAsync(newUser);
        var createdNewUserDto = _mapper.Map<CreatedUserDto>(createdNewUser);

        return CreateActionResult(RequestResponse<CreatedUserDto>.Success(StatusCodes.Status200OK, createdNewUserDto));
    }
}
