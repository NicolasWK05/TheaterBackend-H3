namespace TheaterBackend.Application.Services;

using BCrypt.Net;
using TheaterBackend.Application.Interfaces;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hash)
    {
        return BCrypt.Verify(password, hash);
    }
}
