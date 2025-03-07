using BankApp.Core.Application.Responses;
using BankApp.Core.Requests;
using BankApp.Domain.Enums;
using MediatR;

namespace BankApp.Application.Features.CorporateCreditApplications.Queries.GetList;

public class GetListCorporateCreditApplicationQuery : IRequest<GetListResponse<GetListCorporateCreditApplicationListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public Guid? CorporateCustomerId { get; set; }
    public CreditApplicationStatus? Status { get; set; }

    public GetListCorporateCreditApplicationQuery()
    {
        PageRequest = new PageRequest();
    }
} 