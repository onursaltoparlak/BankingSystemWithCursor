using BankApp.Core.Persistence.Repositories;
using BankApp.Core.Security.Entities;

namespace BankApp.Application.Services.Repositories;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
{
    Task<OperationClaim?> GetByNameAsync(string name);
} 