using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Shared.Common;

namespace Infrastructure.Persistence;

internal class UserManager : IUserManager
{
    private readonly UserManager<AppUser> _userManager;

    public UserManager(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<VoidResult> CreateWithPasswordAsync(AppUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            return Failure.Create(result.Errors.Select(e => e.Description).ToArray());

        return VoidResult.Success();
    }
}
