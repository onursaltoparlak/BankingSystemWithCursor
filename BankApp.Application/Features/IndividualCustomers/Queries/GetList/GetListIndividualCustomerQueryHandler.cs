using AutoMapper;
using BankApp.Application.Services.Repositories;
using BankApp.Core.Application.Responses;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerQueryHandler : IRequestHandler<GetListIndividualCustomerQuery, GetListResponse<GetListIndividualCustomerListItemDto>>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;

    public GetListIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListIndividualCustomerListItemDto>> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
    {
        var individualCustomers = await _individualCustomerRepository.GetListAsync(
            predicate: ic => request.IsActive == null || ic.IsActive == request.IsActive,
            cancellationToken: cancellationToken
        );

        var response = _mapper.Map<GetListResponse<GetListIndividualCustomerListItemDto>>(individualCustomers);
        return response;
    }
} 