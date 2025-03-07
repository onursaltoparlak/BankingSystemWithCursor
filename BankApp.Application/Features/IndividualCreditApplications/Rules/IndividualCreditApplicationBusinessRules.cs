using BankApp.Core.CrossCuttingConcerns.Exceptions;
using BankApp.Application.Services.Repositories;

namespace BankApp.Application.Features.IndividualCreditApplications.Rules;

public class IndividualCreditApplicationBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly ICreditTypeRepository _creditTypeRepository;

    public IndividualCreditApplicationBusinessRules(
        IIndividualCustomerRepository individualCustomerRepository,
        ICreditTypeRepository creditTypeRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _creditTypeRepository = creditTypeRepository;
    }

    public async Task IndividualCustomerShouldExistWhenApplicationCreated(Guid customerId)
    {
        var customer = await _individualCustomerRepository.GetAsync(c => c.Id == customerId);
        if (customer == null)
            throw new BusinessException("Müşteri bulunamadı.");
    }

    public async Task CreditTypeShouldExistWhenApplicationCreated(Guid creditTypeId)
    {
        var creditType = await _creditTypeRepository.GetAsync(ct => ct.Id == creditTypeId);
        if (creditType == null)
            throw new BusinessException("Kredi türü bulunamadı.");
    }
} 