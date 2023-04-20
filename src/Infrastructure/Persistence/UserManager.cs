using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Shared.Common;
using System.Data;

namespace Infrastructure.Persistence;

internal class UserManager : IUserManager
{
    private readonly UserManager<AppUser> _userManager;

    public UserManager(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public Task<AppUser?> FindByUserNameAsync(string userName)
    {
        return _userManager.FindByNameAsync(userName);
    }

    public Task<bool> CheckPasswordAsync(AppUser user, string password)
    {
        return _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<VoidResult> ResetPasswordAsync(AppUser user, string newPassword)
    {
        var removeResult = await _userManager.RemovePasswordAsync(user);

        if (!removeResult.Succeeded)
            return Failure.Create(removeResult.Errors.Select(e => e.Description).ToArray());

        var result = await _userManager.AddPasswordAsync(user, newPassword);

        return result.Succeeded
            ? VoidResult.Success()
            : Failure.Create(result.Errors.Select(e => e.Description).ToArray());
    }

    public async Task<VoidResult> CreateWithPasswordAsync(AppUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);

        return result.Succeeded
            ? VoidResult.Success()
            : Failure.Create(result.Errors.Select(e => e.Description).ToArray());
    }

    public async Task<VoidResult> AddToRoleAsync(AppUser user, string role)
    {
        var result = await _userManager.AddToRoleAsync(user, role);

        return result.Succeeded
            ? VoidResult.Success()
            : Failure.Create(result.Errors.Select(e => e.Description).ToArray());
    }
}
