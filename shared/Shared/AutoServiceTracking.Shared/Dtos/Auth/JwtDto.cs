namespace AutoServiceTracking.Shared.Dtos.Auth;

public class JwtDto
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }

    public string RefreshToken { get; set; } 
    public DateTime RefreshTokenExpiration { get; set; }
}
