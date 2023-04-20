using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class AppRole : IdentityRole<Guid>
{
    public static AppRole Create(string roleName) =>
        new AppRole
        {
            Name = roleName
        };
}
