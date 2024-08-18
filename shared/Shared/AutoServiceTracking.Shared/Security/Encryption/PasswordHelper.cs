using System.Security.Cryptography;
using System.Text;

namespace AutoServiceTracking.Shared.Security.Encryption;

public static class PasswordHelper
{
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using HMACSHA512 hMACSHA512 = new HMACSHA512();

        passwordSalt = hMACSHA512.Key;
        passwordHash = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using HMACSHA512 hMACSHA512 = new HMACSHA512(storedSalt);

        byte[] computedHash = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(storedHash);
    }
}