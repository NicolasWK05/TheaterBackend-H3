using TheaterBackend.Application.Interfaces;

namespace TheaterBackend.Infrastructure.Auth;

public class JwtTokenService : IJwtTokenService
{
    public string GenerateToken(string email, string role)
    {
        // Implementation of token generation logic
        return "generated_token";
    }

    public string DecodeToken(string token)
    {
        // Implementation of token decoding logic
        return "decoded_token";
    }

    public string RefreshToken(string token)
    {
        // Implementation of token refresh logic
        return "refreshed_token";
    }

    public string ValidateToken(string token)
    {
        // Implementation of token validation logic
        return "validated_token";
    }
}
