using Domain.Entities;
using Shared.Common;

namespace Domain.Interfaces;

public interface IUserManager
{
    Task<VoidResult> CreateWithPasswordAsync(AppUser user, string password);
}
