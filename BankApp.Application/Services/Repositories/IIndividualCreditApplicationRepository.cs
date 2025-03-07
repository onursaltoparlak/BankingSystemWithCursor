using BankApp.Core.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Repositories;

public interface IIndividualCreditApplicationRepository : IAsyncRepository<IndividualCreditApplication>, IRepository<IndividualCreditApplication>
{
    Task<IndividualCreditApplication?> GetApplicationByNationalIdAsync(string nationalId);
} 