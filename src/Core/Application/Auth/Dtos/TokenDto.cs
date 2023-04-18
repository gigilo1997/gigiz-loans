namespace Application.Auth.Dtos;

public record TokenDto(
        string Token,
        string RefreshToken,
        DateTime TokenExpiresAtUtc,
        DateTime RefreshTokenExpiresAtUtc);
