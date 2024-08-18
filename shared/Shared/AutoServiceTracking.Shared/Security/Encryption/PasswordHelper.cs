using System.Security.Cryptography;
using System.Text;

namespace AutoServiceTracking.Shared.Security.Encryption;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha1.ComputeHash(passwordBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }

    public static bool VerifyPassword(string password, string hash)
    {
        string passwordHash = HashPassword(password);
        return passwordHash == hash;
    }
}