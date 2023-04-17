using Shared.Common;

namespace Domain.Auth;

public interface IAuthService
{
    Task<ValueResult<AuthContracts.TokenResponse>> GenerateTokenAsync(AuthContracts.GenerateTokenRequest request);
    Task<ValueResult<AuthContracts.TokenResponse>> RefreshTokenAsync(AuthContracts.RefreshTokenRequest request);
}
