using System.Security.Cryptography;

namespace MarineraWebApi.Utils;

public class JwtManager
{
    public static string GenerateKey()
    {
        var key = new byte[32];
        using (var generator = RandomNumberGenerator.Create())
        {
            generator.GetBytes(key);
            return Convert.ToBase64String(key);
        }
    }
}