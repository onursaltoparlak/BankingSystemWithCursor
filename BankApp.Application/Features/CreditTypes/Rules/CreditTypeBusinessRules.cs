using BankApp.Application.Features.CreditTypes.Constants;
using BankApp.Application.Services.Repositories;
using BankApp.Core.Application.Rules;
using BankApp.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankApp.Application.Features.CreditTypes.Rules;

public class CreditTypeBusinessRules : BaseBusinessRules
{
    private readonly ICreditTypeRepository _creditTypeRepository;

    public CreditTypeBusinessRules(ICreditTypeRepository creditTypeRepository)
    {
        _creditTypeRepository = creditTypeRepository;
    }

    public async Task CreditTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        var creditType = await _creditTypeRepository.GetAsync(predicate: b => b.Id == id, cancellationToken: cancellationToken);
        if (creditType is null)
            throw new BusinessException(CreditTypesBusinessMessages.CreditTypeNotExists);
    }

    public async Task CreditTypeNameCannotBeDuplicatedWhenInserted(string name, CancellationToken cancellationToken)
    {
        var creditType = await _creditTypeRepository.GetByNameAsync(name);
        if (creditType is not null)
            throw new BusinessException(CreditTypesBusinessMessages.CreditTypeNameExists);
    }
} 