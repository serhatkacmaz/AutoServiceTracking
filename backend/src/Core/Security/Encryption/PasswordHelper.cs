using System.Security.Cryptography;
using System.Text;

namespace Core.Security.Encryption;

public static class PasswordHelper
{
    /// <summary>
    /// Şifre için hash ve salt oluşturur.
    /// </summary>
    /// <param name="password">Şifre.</param>
    /// <param name="passwordHash">Çıktı: Şifre hash'i.</param>
    /// <param name="passwordSalt">Çıktı: Şifre için kullanılan salt.</param>
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    /// <summary>
    /// Verilen şifreyi hash'ler ve verilen hash ile karşılaştırır.
    /// </summary>
    /// <param name="password">Şifre.</param>
    /// <param name="storedHash">Veritabanında saklanan hash.</param>
    /// <param name="storedSalt">Veritabanında saklanan salt.</param>
    /// <returns>Şifre doğrulandı mı?</returns>
    public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        if (storedHash.Length != 64 || storedSalt.Length != 64)
        {
            throw new InvalidOperationException("Invalid length of hash or salt.");
        }

        using (var hmac = new HMACSHA512(storedSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(storedHash);
        }
    }
}