using BankApp.Core.Persistence.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Domain.Repositories;

public interface ILoanRepository : IAsyncRepository<Loan>, IRepository<Loan>
{
    Task<Loan?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
} 