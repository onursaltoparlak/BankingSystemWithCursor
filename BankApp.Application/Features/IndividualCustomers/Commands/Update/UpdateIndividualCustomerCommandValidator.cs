using FluentValidation;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Update;

public class UpdateIndividualCustomerCommandValidator : AbstractValidator<UpdateIndividualCustomerCommand>
{
    public UpdateIndividualCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.LastName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.NationalId).NotEmpty().Length(11).Matches("^[0-9]*$");
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.PhoneNumber).NotEmpty().Matches("^[0-9+\\- ]*$");
        RuleFor(c => c.Address).NotEmpty().MaximumLength(200);
    }
} 