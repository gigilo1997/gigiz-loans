using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Shared.Common;
using Shared.Constants;

namespace Infrastructure.Persistence;

internal class RoleManager : IRoleManager
{
    private readonly RoleManager<AppRole> _roleManager;

    public RoleManager(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<bool> ExistsAsync(string roleName)
    {
        return await _roleManager.RoleExistsAsync(roleName);
    }

    public async Task<VoidResult> CreateAsync(AppRole role)
    {
        var result = await _roleManager.CreateAsync(role);

        return result.Succeeded
            ? VoidResult.Success()
            : Failure.Create(result.Errors.Select(e => e.Description).ToArray());
    }

    public Task<AppRole?> GetAdminRoleAsync()
    {
        return _roleManager.FindByNameAsync(UserRoleConstants.Admin);
    }
}
