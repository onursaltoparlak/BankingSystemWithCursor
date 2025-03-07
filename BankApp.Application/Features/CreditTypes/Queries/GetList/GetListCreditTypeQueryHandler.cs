using AutoMapper;
using BankApp.Core.Application.Responses;
using BankApp.Domain.Repositories;
using MediatR;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace BankApp.Application.Features.CreditTypes.Queries.GetList;

public class GetListCreditTypeQueryHandler : IRequestHandler<GetListCreditTypeQuery, GetListResponse<GetListCreditTypeListItemDto>>
{
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly IMapper _mapper;

    public GetListCreditTypeQueryHandler(ICreditTypeRepository creditTypeRepository, IMapper mapper)
    {
        _creditTypeRepository = creditTypeRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListCreditTypeListItemDto>> Handle(GetListCreditTypeQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Domain.Entities.CreditType, bool>> predicate = x => true;
        Func<IQueryable<Domain.Entities.CreditType>, IIncludableQueryable<Domain.Entities.CreditType, object>>? include = null;
        var creditTypes = await _creditTypeRepository.GetListAsync(predicate, include, true, true, cancellationToken);
        var mappedCreditTypes = _mapper.Map<GetListResponse<GetListCreditTypeListItemDto>>(creditTypes);
        return mappedCreditTypes;
    }
} 