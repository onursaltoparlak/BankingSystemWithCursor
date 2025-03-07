using BankApp.Core.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Repositories;

public interface ICreditTypeRepository : IAsyncRepository<CreditType>, IRepository<CreditType>
{
    Task<CreditType?> GetByNameAsync(string name);
} 