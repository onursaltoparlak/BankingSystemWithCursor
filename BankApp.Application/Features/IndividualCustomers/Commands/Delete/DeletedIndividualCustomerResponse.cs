namespace BankApp.Application.Features.IndividualCustomers.Commands.Delete;

public class DeletedIndividualCustomerResponse
{
    public required Guid Id { get; set; }
    public required DateTime DeletedDate { get; set; }
} 