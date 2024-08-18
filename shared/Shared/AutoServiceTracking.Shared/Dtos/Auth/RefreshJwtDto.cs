namespace AutoServiceTracking.Shared.Dtos.Auth;

public record RefreshJwtDto
{
    public string Token { get; set; } = null!;
}
