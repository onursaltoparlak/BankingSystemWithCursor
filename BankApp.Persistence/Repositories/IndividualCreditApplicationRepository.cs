using BankApp.Application.Services.Repositories;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Domain.Enums;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace BankApp.Persistence.Repositories;

public class IndividualCreditApplicationRepository : EfRepositoryBase<IndividualCreditApplication, Guid, BaseDbContext>, IIndividualCreditApplicationRepository
{
    public IndividualCreditApplicationRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<IndividualCreditApplication?> GetByIdWithDetailsAsync(Guid id)
    {
        return await Context.Set<IndividualCreditApplication>()
            .Include(ica => ica.IndividualCustomer)
            .Include(ica => ica.CreditType)
            .FirstOrDefaultAsync(ica => ica.Id == id);
    }

    public async Task<List<IndividualCreditApplication>> GetListByCustomerIdAsync(Guid customerId)
    {
        return await Context.Set<IndividualCreditApplication>()
            .Include(ica => ica.CreditType)
            .Where(ica => ica.IndividualCustomerId == customerId)
            .ToListAsync();
    }

    public async Task<List<IndividualCreditApplication>> GetListByStatusAsync(CreditApplicationStatus status)
    {
        return await Context.Set<IndividualCreditApplication>()
            .Include(ica => ica.IndividualCustomer)
            .Include(ica => ica.CreditType)
            .Where(ica => ica.Status == status)
            .ToListAsync();
    }

    public override async Task<IndividualCreditApplication?> GetAsync(Expression<Func<IndividualCreditApplication, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<IndividualCreditApplication>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public override async Task<IList<IndividualCreditApplication>> GetListAsync(
        Expression<Func<IndividualCreditApplication, bool>>? predicate = null,
        Func<IQueryable<IndividualCreditApplication>, IIncludableQueryable<IndividualCreditApplication, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<IndividualCreditApplication>().AsQueryable();
        if (!withDeleted)
            query = query.Where(ica => !ica.IsDeleted);
        if (!enableTracking)
            query = query.AsNoTracking();
        if (include != null)
            query = include(query);
        if (predicate != null)
            query = query.Where(predicate);
        return await query.ToListAsync(cancellationToken);
    }

    public override IndividualCreditApplication Add(IndividualCreditApplication entity)
    {
        Context.Set<IndividualCreditApplication>().Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public override IndividualCreditApplication Update(IndividualCreditApplication entity)
    {
        Context.Set<IndividualCreditApplication>().Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public override IndividualCreditApplication Delete(IndividualCreditApplication entity)
    {
        Context.Set<IndividualCreditApplication>().Remove(entity);
        Context.SaveChanges();
        return entity;
    }

    public override async Task<IndividualCreditApplication> AddAsync(IndividualCreditApplication entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<IndividualCreditApplication>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<IndividualCreditApplication> UpdateAsync(IndividualCreditApplication entity, CancellationToken cancellationToken = default)
    {
        Context.Set<IndividualCreditApplication>().Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<IndividualCreditApplication> DeleteAsync(IndividualCreditApplication entity, CancellationToken cancellationToken = default)
    {
        Context.Set<IndividualCreditApplication>().Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override IndividualCreditApplication? Get(Expression<Func<IndividualCreditApplication, bool>> predicate)
    {
        return Context.Set<IndividualCreditApplication>().FirstOrDefault(predicate);
    }

    public override IList<IndividualCreditApplication> GetList(Expression<Func<IndividualCreditApplication, bool>>? predicate = null)
    {
        var query = Context.Set<IndividualCreditApplication>().AsQueryable();
        if (predicate != null)
            query = query.Where(predicate);
        return query.ToList();
    }

    public async Task<IndividualCreditApplication?> GetApplicationByNationalIdAsync(string nationalId)
    {
        return await Context.Set<IndividualCreditApplication>()
            .Include(ica => ica.IndividualCustomer)
            .Include(ica => ica.CreditType)
            .FirstOrDefaultAsync(ica => ica.IndividualCustomer.NationalId == nationalId);
    }
} 