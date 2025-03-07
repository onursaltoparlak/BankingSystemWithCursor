using BankApp.Core.Persistence.Paging;
using BankApp.Application.Features.CreditTypes.Dtos;

namespace BankApp.Application.Features.CreditTypes.Queries.GetList;

public class GetListCreditTypeResponse : BasePageableModel
{
    public new IList<GetListCreditTypeListItemDto> Items { get; set; } = new List<GetListCreditTypeListItemDto>();
} 