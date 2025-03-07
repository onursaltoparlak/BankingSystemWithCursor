using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
    public DbSet<CreditType> CreditTypes { get; set; }
    public DbSet<IndividualCreditApplication> IndividualCreditApplications { get; set; }
    public DbSet<CorporateCreditApplication> CorporateCreditApplications { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseDbContext).Assembly);
    }
} 