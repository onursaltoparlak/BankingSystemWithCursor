using BankApp.Core.Enums;

namespace BankApp.Application.Features.CreditTypes.DTOs;

public class GetListCreditTypeListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public decimal MinInterestRate { get; set; }
    public decimal MaxInterestRate { get; set; }
    public int MinTermInMonths { get; set; }
    public int MaxTermInMonths { get; set; }
    public bool IsActive { get; set; }
} 