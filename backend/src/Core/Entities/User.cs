

using Core.Entities.Base;

namespace Core.Entities;

public class User : GrandEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; } = true;

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = null!;

    public User()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Status = true;
    }

    public User(string firstName, string lastName, string email, bool status)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Status = status;
    }

    public User(int id, string firstName, string lastName, string email, bool status)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Status = status;
    }
}
