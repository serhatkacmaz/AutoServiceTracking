using AutoMapper;
using Core.Dtos;
using Core.Dtos.User;
using Core.Entities;
using Core.Ioc.Services;
using Microsoft.AspNetCore.Http;
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

    [HttpGet("Users")]
    public async Task<IActionResult> Users()
    {
        var users = await _userService.GetAllAsync();
        var dtoList = _mapper.Map<IEnumerable<GetAllUserDto>>(users);

        return CreateActionResult(ResponseDto<IEnumerable<GetAllUserDto>>.Success(StatusCodes.Status200OK, dtoList));
    }

    [HttpPost("NewUser")]
    public async Task<IActionResult> NewUser([FromBody] CreateUserDto createUserDto)
    {
        var newUser = _mapper.Map<User>(createUserDto);
        var createdNewUser = await _userService.AddAsync(newUser);
        var createdNewUserDto = _mapper.Map<CreatedUserDto>(createdNewUser);

        return CreateActionResult(ResponseDto<CreatedUserDto>.Success(StatusCodes.Status200OK, createdNewUserDto));
    }
}
