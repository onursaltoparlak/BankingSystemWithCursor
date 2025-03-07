using BankApp.Application.Features.CreditTypes.Rules;
using BankApp.Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace BankApp.Application.Features.CreditTypes.Commands.Delete;

public class DeleteCreditTypeCommandHandler : IRequestHandler<DeleteCreditTypeCommand, DeletedCreditTypeResponse>
{
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly IMapper _mapper;
    private readonly CreditTypeBusinessRules _creditTypeBusinessRules;

    public DeleteCreditTypeCommandHandler(ICreditTypeRepository creditTypeRepository, IMapper mapper,
                                       CreditTypeBusinessRules creditTypeBusinessRules)
    {
        _creditTypeRepository = creditTypeRepository;
        _mapper = mapper;
        _creditTypeBusinessRules = creditTypeBusinessRules;
    }

    public async Task<DeletedCreditTypeResponse> Handle(DeleteCreditTypeCommand request, CancellationToken cancellationToken)
    {
        await _creditTypeBusinessRules.CreditTypeIdShouldExistWhenSelected(request.Id, cancellationToken);

        var creditType = await _creditTypeRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        var deletedCreditType = await _creditTypeRepository.DeleteAsync(creditType!, cancellationToken);
        var response = _mapper.Map<DeletedCreditTypeResponse>(deletedCreditType);

        return response;
    }
} 