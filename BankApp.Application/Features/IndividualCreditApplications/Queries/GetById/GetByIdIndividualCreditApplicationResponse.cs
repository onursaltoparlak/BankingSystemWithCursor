using BankApp.Domain.Enums;

namespace BankApp.Application.Features.IndividualCreditApplications.Queries.GetById;

public class GetByIdIndividualCreditApplicationResponse
{
    public Guid Id { get; set; }
    public Guid CreditTypeId { get; set; }
    public required string CreditTypeName { get; set; }
    public Guid IndividualCustomerId { get; set; }
    public required string NationalId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Amount { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public decimal MonthlyIncome { get; set; }
    public string? EmployerName { get; set; }
    public string? EmployerPhone { get; set; }
    public int TermInMonths { get; set; }
    public decimal MonthlyPayment { get; set; }
    public CreditApplicationStatus Status { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? EvaluationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public DateTime? RejectionDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
} 