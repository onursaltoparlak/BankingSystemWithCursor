using BankApp.Core.CrossCuttingConcerns.Exceptions;
using BankApp.Application.Services.Repositories;

namespace BankApp.Application.Features.CorporateCreditApplications.Rules;

public class CorporateCreditApplicationBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly ICorporateCreditApplicationRepository _corporateCreditApplicationRepository;

    public CorporateCreditApplicationBusinessRules(
        ICorporateCustomerRepository corporateCustomerRepository,
        ICreditTypeRepository creditTypeRepository,
        ICorporateCreditApplicationRepository corporateCreditApplicationRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _creditTypeRepository = creditTypeRepository;
        _corporateCreditApplicationRepository = corporateCreditApplicationRepository;
    }

    public async Task CorporateCustomerShouldExistWhenApplicationCreated(Guid customerId)
    {
        var customer = await _corporateCustomerRepository.GetAsync(c => c.Id == customerId);
        if (customer == null)
            throw new BusinessException("Müşteri bulunamadı.");
    }

    public async Task CreditTypeShouldExistWhenApplicationCreated(Guid creditTypeId)
    {
        var creditType = await _creditTypeRepository.GetAsync(ct => ct.Id == creditTypeId);
        if (creditType == null)
            throw new BusinessException("Kredi türü bulunamadı.");
    }

    public async Task CorporateCreditApplicationShouldExistWhenSelected(Guid id)
    {
        var application = await _corporateCreditApplicationRepository.GetAsync(a => a.Id == id);
        if (application == null)
            throw new BusinessException("Kredi başvurusu bulunamadı.");
    }
} 