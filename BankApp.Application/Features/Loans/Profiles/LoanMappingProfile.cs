using AutoMapper;
using BankApp.Application.Features.Loans.Commands.CreateLoan;
using BankApp.Application.Features.Loans.DTOs;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.Loans.Profiles;

public class LoanMappingProfile : Profile
{
    public LoanMappingProfile()
    {
        CreateMap<Loan, LoanDto>();
        CreateMap<CreateLoanCommand, Loan>();
    }
} 