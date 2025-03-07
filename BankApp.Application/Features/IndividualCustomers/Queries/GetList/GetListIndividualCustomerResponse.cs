namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalId { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime CreatedDate { get; set; }
} 