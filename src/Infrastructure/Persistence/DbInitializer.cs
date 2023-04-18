using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal class DbInitializer
{
    private readonly AppDbContext _dbContext;

    public DbInitializer(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InitializeAsync()
    {
        await _dbContext.Database.EnsureCreatedAsync();

        if ((await _dbContext.Database.GetPendingMigrationsAsync()).Any())
            await _dbContext.Database.MigrateAsync();
    }
}
