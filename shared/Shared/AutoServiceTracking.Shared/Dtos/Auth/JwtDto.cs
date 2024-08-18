namespace AutoServiceTracking.Shared.Dtos.Auth;

public record class JwtDto
{
    public string AccessToken { get; set; } = null!;
    public DateTime AccessTokenExpiration { get; set; }

    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpiration { get; set; }
}
