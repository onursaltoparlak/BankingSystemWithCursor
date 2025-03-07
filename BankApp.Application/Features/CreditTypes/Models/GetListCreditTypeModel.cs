using BankApp.Application.Features.CreditTypes.Dtos;
using BankApp.Core.Application.Responses;
using BankApp.Core.Persistence.Paging;

namespace BankApp.Application.Features.CreditTypes.Models;

public class GetListCreditTypeModel : GetListResponse<GetListCreditTypeListItemDto>
{
    public GetListCreditTypeModel(IPaginate<GetListCreditTypeListItemDto> paginate) : base(paginate)
    {
    }
} 