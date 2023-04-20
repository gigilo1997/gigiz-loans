using Domain.Entities;
using Shared.Common;

namespace Domain.Interfaces;

public interface IRoleManager
{
    Task<bool> ExistsAsync(string roleName);
    Task<VoidResult> CreateAsync(AppRole role);
    Task<AppRole?> GetAdminRoleAsync();
}
