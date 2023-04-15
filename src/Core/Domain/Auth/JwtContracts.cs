namespace Domain.Auth;

public static class JwtContracts
{
    public record GenerateTokenRequest(string UserName, string Password);
    public record RefreshTokenRequest(string Token, string RefreshToken);

    public record TokenResponse(
        string Token,
        string RefreshToken,
        DateTime TokenExpiresAtUtc,
        DateTime RefreshTokenExpiresAtUtc);
}
