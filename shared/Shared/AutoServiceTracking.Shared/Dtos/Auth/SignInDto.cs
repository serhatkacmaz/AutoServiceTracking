namespace AutoServiceTracking.Shared.Dtos.Auth;

public record SignInDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
