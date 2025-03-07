using BankApp.Application.Services.Repositories;
using BankApp.Persistence.Contexts;
using BankApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
        services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
        services.AddScoped<ICreditTypeRepository, CreditTypeRepository>();
        services.AddScoped<IIndividualCreditApplicationRepository, IndividualCreditApplicationRepository>();
        services.AddScoped<ICorporateCreditApplicationRepository, CorporateCreditApplicationRepository>();

        return services;
    }
} 