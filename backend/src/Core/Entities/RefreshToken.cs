using Core.Entities.Base;

namespace Core.Entities;

public class RefreshToken : Entity<int>
{
    public int UserId { get; set; }
    public string Code { get; set; }
    public DateTime Expiration { get; set; }

    public virtual User User { get; set; } = null!;

    public RefreshToken() { }
    public RefreshToken(int id, int userId, string code, DateTime expiration) : base(id)
    {
        UserId = userId;
        Code = code;
        Expiration = expiration;
    }
}
