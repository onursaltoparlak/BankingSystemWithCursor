using BankApp.Core.Persistence.Repositories;
using BankApp.Domain.Entities;
using BankApp.Domain.Enums;

namespace BankApp.Application.Repositories;

public interface ICorporateCreditApplicationRepository : IAsyncRepository<CorporateCreditApplication>, IRepository<CorporateCreditApplication>
{
    Task<IList<CorporateCreditApplication>> GetApplicationsByCustomerIdAsync(Guid customerId);
    Task<CorporateCreditApplication?> GetApplicationByTaxNumberAsync(string taxNumber);
    Task<IList<CorporateCreditApplication>> GetApplicationsByStatusAsync(CreditApplicationStatus status);
} 