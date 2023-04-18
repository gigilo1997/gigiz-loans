using Shared.Common;

namespace Domain.Auth;

public interface IAuthService
{
    Task<ValueResult<TokenModel>> GenerateTokenAsync(string userName, string password);
    Task<ValueResult<TokenModel>> RefreshTokenAsync(string token, string refreshToken);
}
