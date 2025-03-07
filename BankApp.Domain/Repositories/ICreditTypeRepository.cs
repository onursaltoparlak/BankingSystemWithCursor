using BankApp.Core.Persistence.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Domain.Repositories;

public interface ICreditTypeRepository : IAsyncRepository<CreditType>, IRepository<CreditType>
{
    Task<CreditType?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
} 