using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BankApp.Persistence.Contexts;

namespace BankApp.Persistence.Migrations;

public static class MigrationManager
{
    public static void MigrateDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BaseDbContext>();
        context.Database.Migrate();
    }

    public static void EnsureDatabaseCreated(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BaseDbContext>();
        context.Database.EnsureCreated();
    }
} 