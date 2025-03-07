using AutoMapper;
using BankApp.Application.Services.Repositories;
using BankApp.Core.Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Application.Features.CorporateCreditApplications.Queries.GetList;

public class GetListCorporateCreditApplicationQueryHandler : IRequestHandler<GetListCorporateCreditApplicationQuery, GetListResponse<GetListCorporateCreditApplicationListItemDto>>
{
    private readonly ICorporateCreditApplicationRepository _corporateCreditApplicationRepository;
    private readonly IMapper _mapper;

    public GetListCorporateCreditApplicationQueryHandler(ICorporateCreditApplicationRepository corporateCreditApplicationRepository, IMapper mapper)
    {
        _corporateCreditApplicationRepository = corporateCreditApplicationRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListCorporateCreditApplicationListItemDto>> Handle(GetListCorporateCreditApplicationQuery request, CancellationToken cancellationToken)
    {
        var corporateCreditApplications = await _corporateCreditApplicationRepository.GetListAsync(
            predicate: null,
            include: x => x.Include(cca => cca.CorporateCustomer).Include(cca => cca.CreditType),
            cancellationToken: cancellationToken
        );

        var response = _mapper.Map<GetListResponse<GetListCorporateCreditApplicationListItemDto>>(corporateCreditApplications);
        return response;
    }
}