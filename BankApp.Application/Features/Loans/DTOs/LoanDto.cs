using BankApp.Domain.Entities;
using BankApp.Domain.Enums;

namespace BankApp.Application.Features.Loans.DTOs;

public class LoanDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int Term { get; set; }
    public decimal InterestRate { get; set; }
    public required string LoanType { get; set; }
    public int CustomerId { get; set; }
    public LoanStatus Status { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
} 