using FluentValidation;

namespace BankApp.Application.Features.IndividualCreditApplications.Commands.Create;

public class CreateIndividualCreditApplicationCommandValidator : AbstractValidator<CreateIndividualCreditApplicationCommand>
{
    public CreateIndividualCreditApplicationCommandValidator()
    {
        RuleFor(ica => ica.CreditTypeId)
            .NotEmpty().WithMessage("Kredi türü seçilmelidir.");

        RuleFor(ica => ica.IndividualCustomerId)
            .NotEmpty().WithMessage("Müşteri seçilmelidir.");

        RuleFor(ica => ica.NationalId)
            .NotEmpty().WithMessage("TC kimlik numarası boş olamaz.")
            .Length(11).WithMessage("TC kimlik numarası 11 haneli olmalıdır.")
            .Matches("^[0-9]*$").WithMessage("TC kimlik numarası sadece rakamlardan oluşmalıdır.");

        RuleFor(ica => ica.FirstName)
            .NotEmpty().WithMessage("Ad boş olamaz.")
            .MaximumLength(50).WithMessage("Ad 50 karakterden uzun olamaz.");

        RuleFor(ica => ica.LastName)
            .NotEmpty().WithMessage("Soyad boş olamaz.")
            .MaximumLength(50).WithMessage("Soyad 50 karakterden uzun olamaz.");

        RuleFor(ica => ica.DateOfBirth)
            .NotEmpty().WithMessage("Doğum tarihi boş olamaz.")
            .LessThan(DateTime.Now).WithMessage("Doğum tarihi bugünden büyük olamaz.");

        RuleFor(ica => ica.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
            .MaximumLength(20).WithMessage("Telefon numarası 20 karakterden uzun olamaz.");

        RuleFor(ica => ica.Email)
            .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
            .MaximumLength(100).WithMessage("E-posta adresi 100 karakterden uzun olamaz.");

        RuleFor(ica => ica.Address)
            .NotEmpty().WithMessage("Adres boş olamaz.")
            .MaximumLength(500).WithMessage("Adres 500 karakterden uzun olamaz.");

        RuleFor(ica => ica.MonthlyIncome)
            .NotEmpty().WithMessage("Aylık gelir boş olamaz.")
            .GreaterThan(0).WithMessage("Aylık gelir 0'dan büyük olmalıdır.");

        RuleFor(ica => ica.Amount)
            .NotEmpty().WithMessage("Kredi tutarı boş olamaz.")
            .GreaterThan(0).WithMessage("Kredi tutarı 0'dan büyük olmalıdır.");

        RuleFor(ica => ica.TermInMonths)
            .NotEmpty().WithMessage("Vade boş olamaz.")
            .GreaterThan(0).WithMessage("Vade 0'dan büyük olmalıdır.");
    }
} 