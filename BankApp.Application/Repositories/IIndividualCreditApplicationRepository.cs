using BankApp.Core.Persistence.Repositories;
using BankApp.Domain.Entities;
using BankApp.Domain.Enums;

namespace BankApp.Application.Repositories;

public interface IIndividualCreditApplicationRepository : IAsyncRepository<IndividualCreditApplication>, IRepository<IndividualCreditApplication>
{
    Task<IList<IndividualCreditApplication>> GetListByStatusAsync(CreditApplicationStatus status);
} 