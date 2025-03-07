using System.Reflection;
using BankApp.Application.Features.CorporateCreditApplications.Rules;
using BankApp.Application.Features.CorporateCustomers.Rules;
using BankApp.Application.Features.CreditTypes.Rules;
using BankApp.Application.Features.IndividualCreditApplications.Rules;
using BankApp.Application.Features.IndividualCustomers.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IndividualCustomerBusinessRules>();
        services.AddScoped<CorporateCustomerBusinessRules>();
        services.AddScoped<CreditTypeBusinessRules>();
        services.AddScoped<IndividualCreditApplicationBusinessRules>();
        services.AddScoped<CorporateCreditApplicationBusinessRules>();

        return services;
    }
} 