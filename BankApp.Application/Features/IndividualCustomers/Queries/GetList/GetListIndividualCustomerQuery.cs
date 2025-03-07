using BankApp.Core.Application.Responses;
using BankApp.Core.Application.Requests;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerQuery : IRequest<GetListResponse<GetListIndividualCustomerListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public bool? IsActive { get; set; }

    public GetListIndividualCustomerQuery()
    {
        PageRequest = new PageRequest();
    }
} 