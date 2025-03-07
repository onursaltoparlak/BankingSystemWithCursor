using BankApp.Application.Features.CorporateCustomers.Constants;
using BankApp.Application.Services.Repositories;
using BankApp.Core.Application.Rules;
using BankApp.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankApp.Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules : BaseBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task CorporateCustomerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken = default)
    {
        var corporateCustomer = await _corporateCustomerRepository.GetAsync(predicate: b => b.Id == id, cancellationToken: cancellationToken);
        if (corporateCustomer is null)
            throw new BusinessException(CorporateCustomersBusinessMessages.CorporateCustomerNotExists);
    }
} 