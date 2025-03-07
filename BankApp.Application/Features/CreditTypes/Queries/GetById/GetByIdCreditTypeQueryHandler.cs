using BankApp.Application.Features.CreditTypes.Rules;
using BankApp.Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace BankApp.Application.Features.CreditTypes.Queries.GetById;

public class GetByIdCreditTypeQueryHandler : IRequestHandler<GetByIdCreditTypeQuery, GetByIdCreditTypeResponse>
{
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly IMapper _mapper;
    private readonly CreditTypeBusinessRules _creditTypeBusinessRules;

    public GetByIdCreditTypeQueryHandler(ICreditTypeRepository creditTypeRepository, IMapper mapper,
                                       CreditTypeBusinessRules creditTypeBusinessRules)
    {
        _creditTypeRepository = creditTypeRepository;
        _mapper = mapper;
        _creditTypeBusinessRules = creditTypeBusinessRules;
    }

    public async Task<GetByIdCreditTypeResponse> Handle(GetByIdCreditTypeQuery request, CancellationToken cancellationToken)
    {
        await _creditTypeBusinessRules.CreditTypeIdShouldExistWhenSelected(request.Id, cancellationToken);

        var creditType = await _creditTypeRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        var response = _mapper.Map<GetByIdCreditTypeResponse>(creditType);

        return response;
    }
} 