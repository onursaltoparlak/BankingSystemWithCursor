using BankApp.Core.Persistence.Repositories;
using BankApp.Core.Security.Entities;
using BankApp.Domain.Repositories;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankApp.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Context.Set<User>()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IList<OperationClaim>> GetClaimsAsync(User user)
    {
        var result = await Context.Set<UserOperationClaim>()
            .Include(uoc => uoc.OperationClaim)
            .Where(uoc => uoc.UserId == user.Id)
            .Select(uoc => uoc.OperationClaim)
            .ToListAsync();

        return result;
    }

    public async Task<User?> GetAsync(Expression<Func<User, bool>> predicate)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(predicate);
    }

    public async Task<User> AddAsync(User entity)
    {
        await Context.Set<User>().AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<User> UpdateAsync(User entity)
    {
        Context.Set<User>().Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<User> DeleteAsync(User entity)
    {
        Context.Set<User>().Remove(entity);
        await Context.SaveChangesAsync();
        return entity;
    }
} 