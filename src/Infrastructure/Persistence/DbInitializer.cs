using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shared.Common;
using Shared.Constants;

namespace Infrastructure.Persistence;

internal class DbInitializer
{
    private readonly AppDbContext _dbContext;
    private readonly IUserManager _userManager;
    private readonly IRoleManager _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<DbInitializer> _logger;

    public DbInitializer(
        AppDbContext dbContext,
        IUserManager userManager,
        IRoleManager roleManager,
        IConfiguration configuration,
        ILogger<DbInitializer> logger)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        _logger.LogInformation("Initializing database");
        await _dbContext.Database.EnsureCreatedAsync();
        _logger.LogInformation("Initialization completed");

        if ((await _dbContext.Database.GetPendingMigrationsAsync()).Any())
        {
            _logger.LogInformation("Migrating database");
            await _dbContext.Database.MigrateAsync();
            _logger.LogInformation("Migration completed");
        }
    }

    public async Task SeedAsync()
    {
        _logger.LogInformation("Seeding database");
        await SeedAdminUser();
        _logger.LogInformation("Database seeded");
    }

    private async Task SeedAdminUser()
    {
        var adminCredentialsSection = _configuration.GetSection("AdminCredentials");
        string username = adminCredentialsSection.GetValue<string>("Username") ?? "admin";
        string password = adminCredentialsSection.GetValue<string>("Password")! ?? "Admin123";

        var admin = await _userManager.FindByUserNameAsync(username);

        if (admin is null)
        {
            admin = AppUser.Create(
                username,
                "Admin",
                "Admin",
                "01010202034",
                new DateTime(1990, 1, 1));

            var creationResult = await _userManager.CreateWithPasswordAsync(admin, password);

            if (!creationResult.IsSuccess)
            {
                _logger.LogError("Failed to seed admin data: {@Error}", Failure.Create(creationResult.ErrorMessages));
                return;
            }
        }

        if (!await _userManager.CheckPasswordAsync(admin, password))
        {
            var resetResult = await _userManager.ResetPasswordAsync(admin, password);
            if (!resetResult.IsSuccess)
            {
                _logger.LogError("Failed to reset admin password: {@Error}", Failure.Create(resetResult.ErrorMessages));
                return;
            }
        }

        var adminRole = await _roleManager.GetAdminRoleAsync();

        if (adminRole is null)
        {
            adminRole = AppRole.Create(UserRoleConstants.Admin);
            var createResult = await _roleManager.CreateAsync(adminRole);
            if (!createResult.IsSuccess)
            {
                _logger.LogError("Failed to create admin role: {@Error}", Failure.Create(createResult.ErrorMessages));
                return;
            }
        }

        var addToRoleResult = await _userManager.AddToRoleAsync(admin, adminRole!.Name!);

        if (!addToRoleResult.IsSuccess)
            _logger.LogError("Failed to add admin user to role: {@Error}", Failure.Create(addToRoleResult.ErrorMessages));
    }
}
