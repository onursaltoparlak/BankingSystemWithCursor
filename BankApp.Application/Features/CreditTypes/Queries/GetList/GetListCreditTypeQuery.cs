using BankApp.Core.Application.Requests;
using BankApp.Core.Application.Responses;
using MediatR;

namespace BankApp.Application.Features.CreditTypes.Queries.GetList;

public class GetListCreditTypeQuery : IRequest<GetListResponse<GetListCreditTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public GetListCreditTypeQuery()
    {
        PageRequest = new PageRequest();
    }
} 