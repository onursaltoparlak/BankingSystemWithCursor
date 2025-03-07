using BankApp.Application.Services.Repositories;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BankApp.Persistence.Repositories;

public class CorporateCustomerRepository : EfRepositoryBase<CorporateCustomer, Guid, BaseDbContext>, ICorporateCustomerRepository
{
    public CorporateCustomerRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<CorporateCustomer?> GetByTaxNumberAsync(string taxNumber)
    {
        return await Context.Set<CorporateCustomer>()
            .FirstOrDefaultAsync(cc => cc.TaxNumber == taxNumber);
    }

    public async Task<CorporateCustomer?> GetByIdWithDetailsAsync(Guid id)
    {
        return await Context.Set<CorporateCustomer>()
            .Include(cc => cc.CreditApplications)
            .FirstOrDefaultAsync(cc => cc.Id == id);
    }

    public override async Task<CorporateCustomer?> GetAsync(Expression<Func<CorporateCustomer, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<CorporateCustomer>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public override async Task<IList<CorporateCustomer>> GetListAsync(
        Expression<Func<CorporateCustomer, bool>>? predicate = null,
        Func<IQueryable<CorporateCustomer>, IIncludableQueryable<CorporateCustomer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<CorporateCustomer>().AsQueryable();
        if (!withDeleted)
            query = query.Where(cc => !cc.IsDeleted);
        if (!enableTracking)
            query = query.AsNoTracking();
        if (include != null)
            query = include(query);
        if (predicate != null)
            query = query.Where(predicate);
        return await query.ToListAsync(cancellationToken);
    }

    public override CorporateCustomer? Get(Expression<Func<CorporateCustomer, bool>> predicate)
    {
        return Context.Set<CorporateCustomer>().FirstOrDefault(predicate);
    }

    public override IList<CorporateCustomer> GetList(Expression<Func<CorporateCustomer, bool>>? predicate = null)
    {
        var query = Context.Set<CorporateCustomer>().AsQueryable();
        if (predicate != null)
            query = query.Where(predicate);
        return query.ToList();
    }

    public override CorporateCustomer Add(CorporateCustomer entity)
    {
        Context.Set<CorporateCustomer>().Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public override CorporateCustomer Update(CorporateCustomer entity)
    {
        Context.Set<CorporateCustomer>().Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public override CorporateCustomer Delete(CorporateCustomer entity)
    {
        Context.Set<CorporateCustomer>().Remove(entity);
        Context.SaveChanges();
        return entity;
    }

    public override async Task<CorporateCustomer> AddAsync(CorporateCustomer entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<CorporateCustomer>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<CorporateCustomer> UpdateAsync(CorporateCustomer entity, CancellationToken cancellationToken = default)
    {
        Context.Set<CorporateCustomer>().Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<CorporateCustomer> DeleteAsync(CorporateCustomer entity, CancellationToken cancellationToken = default)
    {
        Context.Set<CorporateCustomer>().Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }
} 