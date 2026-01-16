namespace TheaterBackend.Application.Services;

using System.Security.Cryptography;
using System.Text;
using TheaterBackend.Application.Interfaces;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        return Convert.ToBase64String(sha256.ComputeHash(bytes));
    }

    public bool Verify(string password, string hash) => Hash(password) == hash;
}
