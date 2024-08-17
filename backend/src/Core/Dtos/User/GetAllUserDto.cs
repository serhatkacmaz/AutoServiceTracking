using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.User;

public record GetAllUserDto
{
    public string FirstName { get; set; }
    public string Email { get; set; }

    public GetAllUserDto(string firstName, string email)
    {
        FirstName = firstName;
        Email = email;
    }
}
