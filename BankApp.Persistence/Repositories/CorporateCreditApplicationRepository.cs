using BankApp.Application.Services.Repositories;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Domain.Enums;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BankApp.Persistence.Repositories;

public class CorporateCreditApplicationRepository : EfRepositoryBase<CorporateCreditApplication, Guid, BaseDbContext>, ICorporateCreditApplicationRepository
{
    public CorporateCreditApplicationRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<CorporateCreditApplication?> GetByIdWithDetailsAsync(Guid id)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CorporateCustomer)
            .Include(cca => cca.CreditType)
            .FirstOrDefaultAsync(cca => cca.Id == id);
    }

    public async Task<List<CorporateCreditApplication>> GetListByCustomerIdAsync(Guid customerId)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CreditType)
            .Where(cca => cca.CorporateCustomerId == customerId)
            .ToListAsync();
    }

    public async Task<List<CorporateCreditApplication>> GetListByStatusAsync(CreditApplicationStatus status)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CorporateCustomer)
            .Include(cca => cca.CreditType)
            .Where(cca => cca.Status == status)
            .ToListAsync();
    }

    public async Task<List<CorporateCreditApplication>> GetListByCorporateCustomerIdAsync(Guid corporateCustomerId)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CorporateCustomer)
            .Include(cca => cca.CreditType)
            .Where(cca => cca.CorporateCustomerId == corporateCustomerId)
            .ToListAsync();
    }

    public async Task<List<CorporateCreditApplication>> GetListByCreditTypeIdAsync(Guid creditTypeId)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CorporateCustomer)
            .Include(cca => cca.CreditType)
            .Where(cca => cca.CreditTypeId == creditTypeId)
            .ToListAsync();
    }

    public async Task<List<CorporateCreditApplication>> GetListByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CorporateCustomer)
            .Include(cca => cca.CreditType)
            .Where(cca => cca.ApplicationDate >= startDate && cca.ApplicationDate <= endDate)
            .ToListAsync();
    }

    public async Task<CorporateCreditApplication?> GetByTaxNumberAsync(string taxNumber)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CorporateCustomer)
            .Include(cca => cca.CreditType)
            .FirstOrDefaultAsync(cca => cca.TaxNumber == taxNumber);
    }

    public async Task<List<CorporateCreditApplication>> GetListByCompanyNameAsync(string companyName)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CorporateCustomer)
            .Include(cca => cca.CreditType)
            .Where(cca => cca.CompanyName.Contains(companyName))
            .ToListAsync();
    }

    public async Task<List<CorporateCreditApplication>> GetListByAmountRangeAsync(decimal minAmount, decimal maxAmount)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CorporateCustomer)
            .Include(cca => cca.CreditType)
            .Where(cca => cca.Amount >= minAmount && cca.Amount <= maxAmount)
            .ToListAsync();
    }

    public async Task<List<CorporateCreditApplication>> GetListByEmployeeCountRangeAsync(int minCount, int maxCount)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CorporateCustomer)
            .Include(cca => cca.CreditType)
            .Where(cca => cca.EmployeeCount >= minCount && cca.EmployeeCount <= maxCount)
            .ToListAsync();
    }

    public async Task<IList<CorporateCreditApplication>> GetByStatusAsync(CreditApplicationStatus status)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CreditType)
            .Include(cca => cca.CorporateCustomer)
            .Where(cca => cca.Status == status)
            .ToListAsync();
    }

    public async Task<IList<CorporateCreditApplication>> GetByCustomerIdAsync(Guid customerId)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CreditType)
            .Include(cca => cca.CorporateCustomer)
            .Where(cca => cca.CorporateCustomerId == customerId)
            .ToListAsync();
    }

    public async Task<CorporateCreditApplication?> GetApplicationByTaxNumberAsync(string taxNumber)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CorporateCustomer)
            .Include(cca => cca.CreditType)
            .FirstOrDefaultAsync(cca => cca.TaxNumber == taxNumber);
    }

    public async Task<IList<CorporateCreditApplication>> GetApplicationsByStatusAsync(CreditApplicationStatus status)
    {
        return await Context.Set<CorporateCreditApplication>()
            .Include(cca => cca.CreditType)
            .Include(cca => cca.CorporateCustomer)
            .Where(cca => cca.Status == status)
            .ToListAsync();
    }

    public override CorporateCreditApplication? Get(Expression<Func<CorporateCreditApplication, bool>> predicate)
    {
        return Context.Set<CorporateCreditApplication>().FirstOrDefault(predicate);
    }

    public override IList<CorporateCreditApplication> GetList(Expression<Func<CorporateCreditApplication, bool>>? predicate = null)
    {
        var query = Context.Set<CorporateCreditApplication>().AsQueryable();
        if (predicate != null)
            query = query.Where(predicate);
        return query.ToList();
    }

    public override async Task<CorporateCreditApplication?> GetAsync(Expression<Func<CorporateCreditApplication, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<CorporateCreditApplication>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public override async Task<IList<CorporateCreditApplication>> GetListAsync(
        Expression<Func<CorporateCreditApplication, bool>>? predicate = null,
        Func<IQueryable<CorporateCreditApplication>, IIncludableQueryable<CorporateCreditApplication, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<CorporateCreditApplication>().AsQueryable();
        if (!enableTracking)
            query = query.AsNoTracking();
        if (include != null)
            query = include(query);
        if (predicate != null)
            query = query.Where(predicate);
        return await query.ToListAsync(cancellationToken);
    }

    public override CorporateCreditApplication Add(CorporateCreditApplication entity)
    {
        Context.Set<CorporateCreditApplication>().Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public override CorporateCreditApplication Update(CorporateCreditApplication entity)
    {
        Context.Set<CorporateCreditApplication>().Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public override CorporateCreditApplication Delete(CorporateCreditApplication entity)
    {
        Context.Set<CorporateCreditApplication>().Remove(entity);
        Context.SaveChanges();
        return entity;
    }

    public override async Task<CorporateCreditApplication> AddAsync(CorporateCreditApplication entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<CorporateCreditApplication>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<CorporateCreditApplication> UpdateAsync(CorporateCreditApplication entity, CancellationToken cancellationToken = default)
    {
        Context.Set<CorporateCreditApplication>().Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<CorporateCreditApplication> DeleteAsync(CorporateCreditApplication entity, CancellationToken cancellationToken = default)
    {
        Context.Set<CorporateCreditApplication>().Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }
} 