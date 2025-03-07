using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Update;

public class UpdateCorporateCustomerCommand : IRequest<UpdatedCorporateCustomerResponse>
{
    public Guid Id { get; set; }
    public required string CompanyName { get; set; }
    public required string TaxNumber { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public required string Email { get; set; }
} 