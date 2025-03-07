using BankApp.Core.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Repositories;

public interface IIndividualCustomerRepository : IAsyncRepository<IndividualCustomer>, IRepository<IndividualCustomer>
{
    Task<IndividualCustomer?> GetByNationalIdAsync(string nationalId);
} 