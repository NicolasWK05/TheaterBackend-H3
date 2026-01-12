namespace TheaterBackend.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(string email, string role);
    string RefreshToken(string token);
    string ValidateToken(string token);
    string DecodeToken(string token);
}
