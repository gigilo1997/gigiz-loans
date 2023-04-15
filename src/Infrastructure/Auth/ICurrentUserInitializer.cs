using System.Security.Claims;

namespace Infrastructure.Auth;

internal interface ICurrentUserInitializer
{
    void SetCurrentUser(ClaimsPrincipal user);
}
