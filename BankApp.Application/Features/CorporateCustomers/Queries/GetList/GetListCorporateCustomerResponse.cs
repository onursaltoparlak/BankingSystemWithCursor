namespace BankApp.Application.Features.CorporateCustomers.Queries.GetList;

public class GetListCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public required string CompanyName { get; set; }
    public required string TaxNumber { get; set; }
    public required string TaxOffice { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime CreatedDate { get; set; }
} 