using BankApp.Core.Persistence.Repositories;
using BankApp.Core.Security.Entities;

namespace BankApp.Domain.Repositories;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<IList<OperationClaim>> GetClaimsAsync(User user);
} 