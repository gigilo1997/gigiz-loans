using Domain.Auth;
using Domain.Exceptions;
using Shared.Extensions;
using System.Security.Claims;

namespace Infrastructure.Auth;

internal class CurrentUserService : ICurrentUser, ICurrentUserInitializer
{
    private ClaimsPrincipal? _user;

    public Guid? GetUserId() =>
        _user?.GetUserId();

    public bool IsAuthenticated() =>
        _user?.Identity?.IsAuthenticated is true;

    public void SetCurrentUser(ClaimsPrincipal user)
        => _user = user;
}
