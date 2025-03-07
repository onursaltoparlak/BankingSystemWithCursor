using BankApp.Core.Persistence.Repositories;
using BankApp.Core.Security.Entities;

namespace BankApp.Application.Services.Repositories;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
{
    Task<IList<UserOperationClaim>> GetByUserIdAsync(Guid userId);
} 