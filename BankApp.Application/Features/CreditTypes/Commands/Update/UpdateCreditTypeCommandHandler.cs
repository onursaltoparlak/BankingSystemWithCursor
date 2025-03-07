using BankApp.Application.Features.CreditTypes.Rules;
using BankApp.Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace BankApp.Application.Features.CreditTypes.Commands.Update;

public class UpdateCreditTypeCommandHandler : IRequestHandler<UpdateCreditTypeCommand, UpdatedCreditTypeResponse>
{
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly IMapper _mapper;
    private readonly CreditTypeBusinessRules _creditTypeBusinessRules;

    public UpdateCreditTypeCommandHandler(ICreditTypeRepository creditTypeRepository, IMapper mapper,
                                       CreditTypeBusinessRules creditTypeBusinessRules)
    {
        _creditTypeRepository = creditTypeRepository;
        _mapper = mapper;
        _creditTypeBusinessRules = creditTypeBusinessRules;
    }

    public async Task<UpdatedCreditTypeResponse> Handle(UpdateCreditTypeCommand request, CancellationToken cancellationToken)
    {
        await _creditTypeBusinessRules.CreditTypeIdShouldExistWhenSelected(request.Id, cancellationToken);

        var creditType = await _creditTypeRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        _mapper.Map(request, creditType);
        var updatedCreditType = await _creditTypeRepository.UpdateAsync(creditType!, cancellationToken);
        var response = _mapper.Map<UpdatedCreditTypeResponse>(updatedCreditType);

        return response;
    }
} 