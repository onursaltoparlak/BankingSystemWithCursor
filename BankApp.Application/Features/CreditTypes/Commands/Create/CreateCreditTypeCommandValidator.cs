using FluentValidation;

namespace BankApp.Application.Features.CreditTypes.Commands.Create;

public class CreateCreditTypeCommandValidator : AbstractValidator<CreateCreditTypeCommand>
{
    public CreateCreditTypeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(500);

        RuleFor(x => x.MinAmount)
            .GreaterThan(0)
            .LessThan(x => x.MaxAmount);

        RuleFor(x => x.MaxAmount)
            .GreaterThan(x => x.MinAmount);

        RuleFor(x => x.MinInterestRate)
            .GreaterThan(0)
            .LessThan(x => x.MaxInterestRate);

        RuleFor(x => x.MaxInterestRate)
            .GreaterThan(x => x.MinInterestRate);

        RuleFor(x => x.MinTermInMonths)
            .GreaterThan(0)
            .LessThan(x => x.MaxTermInMonths);

        RuleFor(x => x.MaxTermInMonths)
            .GreaterThan(x => x.MinTermInMonths);
    }
} 