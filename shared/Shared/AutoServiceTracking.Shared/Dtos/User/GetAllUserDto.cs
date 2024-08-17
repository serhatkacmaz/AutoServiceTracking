namespace AutoServiceTracking.Shared.Dtos.User;

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
