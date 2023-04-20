using Domain.Entities;
using Shared.Common;

namespace Domain.Interfaces;

public interface IUserManager
{
    Task<AppUser?> FindByUserNameAsync(string userName);
    Task<bool> CheckPasswordAsync(AppUser user, string password);
    Task<VoidResult> ResetPasswordAsync(AppUser user, string newPassword);
    Task<VoidResult> CreateWithPasswordAsync(AppUser user, string password);
    Task<VoidResult> AddToRoleAsync(AppUser user, string role);
}
