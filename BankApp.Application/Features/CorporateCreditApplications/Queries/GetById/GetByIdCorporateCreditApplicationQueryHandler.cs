using AutoMapper;
using BankApp.Application.Features.CorporateCreditApplications.Rules;
using BankApp.Application.Services.Repositories;
using MediatR;

namespace BankApp.Application.Features.CorporateCreditApplications.Queries.GetById;

public class GetByIdCorporateCreditApplicationQueryHandler : IRequestHandler<GetByIdCorporateCreditApplicationQuery, GetByIdCorporateCreditApplicationResponse>
{
    private readonly ICorporateCreditApplicationRepository _corporateCreditApplicationRepository;
    private readonly IMapper _mapper;
    private readonly CorporateCreditApplicationBusinessRules _businessRules;

    public GetByIdCorporateCreditApplicationQueryHandler(
        ICorporateCreditApplicationRepository corporateCreditApplicationRepository,
        IMapper mapper,
        CorporateCreditApplicationBusinessRules businessRules)
    {
        _corporateCreditApplicationRepository = corporateCreditApplicationRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<GetByIdCorporateCreditApplicationResponse> Handle(GetByIdCorporateCreditApplicationQuery request, CancellationToken cancellationToken)
    {
        await _businessRules.CorporateCreditApplicationShouldExistWhenSelected(request.Id);
        var application = await _corporateCreditApplicationRepository.GetAsync(cca => cca.Id == request.Id);

        var response = _mapper.Map<GetByIdCorporateCreditApplicationResponse>(application);
        return response;
    }
} 