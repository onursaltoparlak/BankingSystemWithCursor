using BankApp.Core.Application.Requests;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Queries.GetList;

public class GetListCorporateCustomerQuery : IRequest<IList<GetListCorporateCustomerListItemDto>>
{
    public PageRequest? PageRequest { get; set; }

    public GetListCorporateCustomerQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }
} 