using BankApp.Core.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Repositories;

public interface ICorporateCustomerRepository : IAsyncRepository<CorporateCustomer>, IRepository<CorporateCustomer>
{
    Task<CorporateCustomer?> GetByTaxNumberAsync(string taxNumber);
} 