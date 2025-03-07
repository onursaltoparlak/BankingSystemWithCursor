using BankApp.Application.Services.Repositories;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Core.Enums;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading;

namespace BankApp.Persistence.Repositories;

public class CreditTypeRepository : EfRepositoryBase<CreditType, Guid, BaseDbContext>, ICreditTypeRepository
{
    public CreditTypeRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<CreditType?> GetByNameAsync(string name)
    {
        return await Context.Set<CreditType>()
            .FirstOrDefaultAsync(ct => ct.Name == name);
    }

    public async Task<CreditType?> GetByIdWithDetailsAsync(Guid id)
    {
        return await Context.Set<CreditType>()
            .Include(ct => ct.CorporateCreditApplications)
            .Include(ct => ct.IndividualCreditApplications)
            .FirstOrDefaultAsync(ct => ct.Id == id);
    }

    public async Task<List<CreditType>> GetListByIdsAsync(IList<Guid> ids)
    {
        return await Context.Set<CreditType>()
            .Where(ct => ids.Contains(ct.Id))
            .ToListAsync();
    }

    public async Task<List<CreditType>> GetListByCategoryAsync(CreditTypeCategory category)
    {
        return await Context.Set<CreditType>()
            .Where(ct => ct.Category == category)
            .ToListAsync();
    }

    public async Task<IList<CreditType>> GetActivesAsync()
    {
        return await Context.Set<CreditType>()
            .Where(ct => ct.IsActive)
            .ToListAsync();
    }

    public async Task<IList<CreditType>> GetActiveCreditTypesByCategoryAsync(CreditTypeCategory category)
    {
        return await Context.Set<CreditType>()
            .Where(ct => ct.IsActive && ct.Category == category)
            .ToListAsync();
    }

    public async Task<CreditType?> GetCreditTypeByNameAsync(string name)
    {
        return await Context.Set<CreditType>()
            .FirstOrDefaultAsync(ct => ct.Name == name);
    }

    public async Task<List<CreditType>> GetListByStatusAsync(bool isActive)
    {
        return await Context.Set<CreditType>()
            .Where(ct => ct.IsActive == isActive)
            .ToListAsync();
    }

    public override async Task<CreditType?> GetAsync(Expression<Func<CreditType, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<CreditType>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public override async Task<IList<CreditType>> GetListAsync(
        Expression<Func<CreditType, bool>>? predicate = null,
        Func<IQueryable<CreditType>, IIncludableQueryable<CreditType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<CreditType>().AsQueryable();
        if (!withDeleted)
            query = query.Where(ct => !ct.IsDeleted);
        if (!enableTracking)
            query = query.AsNoTracking();
        if (include != null)
            query = include(query);
        if (predicate != null)
            query = query.Where(predicate);
        return await query.ToListAsync(cancellationToken);
    }

    public override CreditType Add(CreditType entity)
    {
        Context.Set<CreditType>().Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public override CreditType Update(CreditType entity)
    {
        Context.Set<CreditType>().Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public override CreditType Delete(CreditType entity)
    {
        Context.Set<CreditType>().Remove(entity);
        Context.SaveChanges();
        return entity;
    }

    public override CreditType? Get(Expression<Func<CreditType, bool>> predicate)
    {
        return Context.Set<CreditType>().FirstOrDefault(predicate);
    }

    public override IList<CreditType> GetList(Expression<Func<CreditType, bool>>? predicate = null)
    {
        var query = Context.Set<CreditType>().AsQueryable();
        if (predicate != null)
            query = query.Where(predicate);
        return query.ToList();
    }

    public override async Task<CreditType> AddAsync(CreditType entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<CreditType>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<CreditType> UpdateAsync(CreditType entity, CancellationToken cancellationToken = default)
    {
        Context.Set<CreditType>().Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<CreditType> DeleteAsync(CreditType entity, CancellationToken cancellationToken = default)
    {
        Context.Set<CreditType>().Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }
} 