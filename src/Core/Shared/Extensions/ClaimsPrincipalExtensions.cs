using System.Security.Claims;

namespace Shared.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid? GetUserId(this ClaimsPrincipal principal)
       => Guid.TryParse(principal.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId)
        ? userId
        : null;

    public static string? GetUsername(this ClaimsPrincipal principal)
        => principal.FindFirstValue(ClaimTypes.Name);

    public static string? GetFirstName(this ClaimsPrincipal principal)
        => principal?.FindFirst(ClaimTypes.GivenName)?.Value;

    public static string? GetLastName(this ClaimsPrincipal principal)
        => principal?.FindFirst(ClaimTypes.Surname)?.Value;

    private static string? FindFirstValue(this ClaimsPrincipal principal, string claimType) =>
        principal is null
            ? throw new ArgumentNullException(nameof(principal))
            : principal.FindFirst(claimType)?.Value;
}
