using AutoMapper;
using BankApp.Application.Services.Repositories;
using BankApp.Core.Application.Responses;
using MediatR;
using System.Linq.Expressions;
using System.Linq;
using BankApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Application.Features.IndividualCreditApplications.Queries.GetList;

public class GetListIndividualCreditApplicationQueryHandler : IRequestHandler<GetListIndividualCreditApplicationQuery, GetListResponse<GetListIndividualCreditApplicationListItemDto>>
{
    private readonly IIndividualCreditApplicationRepository _individualCreditApplicationRepository;
    private readonly IMapper _mapper;

    public GetListIndividualCreditApplicationQueryHandler(IIndividualCreditApplicationRepository individualCreditApplicationRepository, IMapper mapper)
    {
        _individualCreditApplicationRepository = individualCreditApplicationRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListIndividualCreditApplicationListItemDto>> Handle(GetListIndividualCreditApplicationQuery request, CancellationToken cancellationToken)
    {
        var individualCreditApplications = await _individualCreditApplicationRepository.GetListAsync(
            predicate: null,
            cancellationToken: cancellationToken
        );

        var response = _mapper.Map<GetListResponse<GetListIndividualCreditApplicationListItemDto>>(individualCreditApplications);
        return response;
    }
}