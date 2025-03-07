using BankApp.Application.Services.Repositories;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading;

namespace BankApp.Persistence.Repositories;

public class IndividualCustomerRepository : EfRepositoryBase<IndividualCustomer, Guid, BaseDbContext>, IIndividualCustomerRepository
{
    public IndividualCustomerRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<IndividualCustomer?> GetByIdentityNumberAsync(string identityNumber)
    {
        return await Context.Set<IndividualCustomer>()
            .AsNoTracking()
            .FirstOrDefaultAsync(ic => ic.NationalId == identityNumber);
    }

    public async Task<IndividualCustomer?> GetByIdWithDetailsAsync(Guid id)
    {
        return await Context.Set<IndividualCustomer>()
            .Include(ic => ic.CreditApplications)
            .AsNoTracking()
            .FirstOrDefaultAsync(ic => ic.Id == id);
    }

    public async Task<IndividualCustomer?> GetByNationalIdAsync(string nationalId)
    {
        return await Context.Set<IndividualCustomer>()
            .AsNoTracking()
            .FirstOrDefaultAsync(ic => ic.NationalId == nationalId);
    }
}
