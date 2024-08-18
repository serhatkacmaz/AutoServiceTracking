namespace AutoServiceTracking.Shared.Dtos.Auth;

public record RefreshTokenDto
{
    public string Token { get; set; } = null!;
}
