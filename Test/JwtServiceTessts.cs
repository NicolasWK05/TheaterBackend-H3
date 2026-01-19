using Xunit;
using TheaterBackend.Application.Services;

public class JwtServiceTests
{
    [Fact]
    public void GenerateToken_ReturnsNonEmptyString()
    {
        var service = new JwtTokenService("01234567890123456789012345678901", "iss", "aud");

        var token = service.GenerateToken("test@test.com", "User", 1);

        Assert.False(string.IsNullOrWhiteSpace(token));
    }
}
