using BankApp.Core.Persistence.Repositories;
using BankApp.Core.Security.Entities;

namespace BankApp.Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<IList<OperationClaim>> GetOperationClaimsAsync(User user);
} 