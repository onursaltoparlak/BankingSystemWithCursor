using BankApp.Core.Application.Responses;
using BankApp.Core.Requests;
using BankApp.Domain.Enums;
using MediatR;

namespace BankApp.Application.Features.IndividualCreditApplications.Queries.GetList;

public class GetListIndividualCreditApplicationQuery : IRequest<GetListResponse<GetListIndividualCreditApplicationListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public CreditApplicationStatus? Status { get; set; }

    public GetListIndividualCreditApplicationQuery()
    {
        PageRequest = new PageRequest();
    }
} 