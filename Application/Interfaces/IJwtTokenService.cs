namespace TheaterBackend.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(string email, string role);
    string DecodeToken(string token);
    string RefreshToken(string token);
    bool ValidateToken(string token);
}
