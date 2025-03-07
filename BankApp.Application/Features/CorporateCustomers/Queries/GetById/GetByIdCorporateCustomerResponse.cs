namespace BankApp.Application.Features.CorporateCustomers.Queries.GetById;

public class GetByIdCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public required string CompanyName { get; set; }
    public required string TaxNumber { get; set; }
    public required string TaxOffice { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public required string Website { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
} 