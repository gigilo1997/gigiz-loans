using Domain.Auth;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Common;
using Shared.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Auth;

internal class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly JwtSettings _jwtSettings;

    public AuthService(
        UserManager<AppUser> userManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
    }

    public async Task<ValueResult<TokenModel>> GenerateTokenAsync(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user is null)
            return Failure.Create("Incorrect Email or Password");

        if (!await _userManager.CheckPasswordAsync(user, password))
            return Failure.Create("Incorrect Email or Password");

        return await GenerateTokenFromUser(user);
    }

    public async Task<ValueResult<TokenModel>> RefreshTokenAsync(string token, string refreshToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
            ValidateIssuer = true,
            ValidIssuer = _jwtSettings.Issuer,
            ValidateLifetime = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler
            .ValidateToken(token, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            return Failure.Create("Invalid Token");
        }

        string? userName = principal.GetUsername();

        if (string.IsNullOrEmpty(userName))
            return Failure.Create("Invalid Token");

        var user = await _userManager.FindByNameAsync(userName);

        if (user is null)
            return Failure.Create("Invalid Token");

        if (user.RefreshToken != refreshToken)
            return Failure.Create("Invalid Refresh token");

        return await GenerateTokenFromUser(user);
    }

    private async Task<TokenModel> GenerateTokenFromUser(AppUser user)
    {
        DateTime now = DateTime.UtcNow;
        DateTime tokenExpiresAt = now.AddMinutes(_jwtSettings.TokenExpirationInMinutes);
        DateTime refreshTokenExpiresAt = now.AddDays(_jwtSettings.RefreshTokenExpirationInDays);

        // Generate jwt token
        byte[] secret = Encoding.UTF8.GetBytes(_jwtSettings.Key);
        SigningCredentials signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName!),
            new(ClaimTypes.GivenName, user.FirstName ?? string.Empty),
            new(ClaimTypes.Surname, user.LastName ?? string.Empty)
        };

        var token = new JwtSecurityToken(
           claims: claims,
           issuer: _jwtSettings.Issuer,
           expires: tokenExpiresAt,
           signingCredentials: signingCredentials);
        var tokenHandler = new JwtSecurityTokenHandler();

        string tokenString = tokenHandler.WriteToken(token);

        // Generate refresh token
        byte[] randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        string refreshToken = Convert.ToBase64String(randomNumber);

        user.UpdateRefreshToken(refreshToken, refreshTokenExpiresAt);
        await _userManager.UpdateAsync(user);

        return new TokenModel(tokenString, refreshToken, tokenExpiresAt, refreshTokenExpiresAt);
    }
}
