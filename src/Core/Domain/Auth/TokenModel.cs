namespace Domain.Auth;

public record TokenModel(
        string Token,
        string RefreshToken,
        DateTime TokenExpiresAtUtc,
        DateTime RefreshTokenExpiresAtUtc);
