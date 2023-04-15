using Shared.Common;

namespace Domain.Auth;

public interface IJwtService
{
    Task<ValueResult<JwtContracts.TokenResponse>> GenerateTokenAsync(JwtContracts.GenerateTokenRequest request);
    Task<ValueResult<JwtContracts.TokenResponse>> RefreshTokenAsync(JwtContracts.RefreshTokenRequest request);
}
