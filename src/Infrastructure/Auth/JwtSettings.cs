namespace Infrastructure.Auth;

internal class JwtSettings
{
    public const string SectionName = nameof(JwtSettings);

    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public int TokenExpirationInMinutes { get; set; }
    public int RefreshTokenExpirationInDays { get; set; }
}
