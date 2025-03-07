using FluentValidation;

namespace BankApp.Application.Features.CorporateCreditApplications.Commands.Create;

public class CreateCorporateCreditApplicationCommandValidator : AbstractValidator<CreateCorporateCreditApplicationCommand>
{
    public CreateCorporateCreditApplicationCommandValidator()
    {
        RuleFor(cca => cca.CreditTypeId)
            .NotEmpty().WithMessage("Kredi türü seçilmelidir.");

        RuleFor(cca => cca.CorporateCustomerId)
            .NotEmpty().WithMessage("Müşteri seçilmelidir.");

        RuleFor(cca => cca.TaxNumber)
            .NotEmpty().WithMessage("Vergi numarası boş olamaz.")
            .Length(10).WithMessage("Vergi numarası 10 haneli olmalıdır.")
            .Matches("^[0-9]*$").WithMessage("Vergi numarası sadece rakamlardan oluşmalıdır.");

        RuleFor(cca => cca.CompanyName)
            .NotEmpty().WithMessage("Şirket adı boş olamaz.")
            .MaximumLength(100).WithMessage("Şirket adı 100 karakterden uzun olamaz.");

        RuleFor(cca => cca.CompanyType)
            .NotEmpty().WithMessage("Şirket türü boş olamaz.")
            .MaximumLength(50).WithMessage("Şirket türü 50 karakterden uzun olamaz.");

        RuleFor(cca => cca.EstablishmentDate)
            .NotEmpty().WithMessage("Kuruluş tarihi boş olamaz.")
            .LessThan(DateTime.Now).WithMessage("Kuruluş tarihi bugünden büyük olamaz.");

        RuleFor(cca => cca.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
            .MaximumLength(20).WithMessage("Telefon numarası 20 karakterden uzun olamaz.");

        RuleFor(cca => cca.Email)
            .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
            .MaximumLength(100).WithMessage("E-posta adresi 100 karakterden uzun olamaz.");

        RuleFor(cca => cca.Address)
            .NotEmpty().WithMessage("Adres boş olamaz.")
            .MaximumLength(500).WithMessage("Adres 500 karakterden uzun olamaz.");

        RuleFor(cca => cca.AnnualRevenue)
            .NotEmpty().WithMessage("Yıllık gelir boş olamaz.")
            .GreaterThan(0).WithMessage("Yıllık gelir 0'dan büyük olmalıdır.");

        RuleFor(cca => cca.EmployeeCount)
            .NotEmpty().WithMessage("Çalışan sayısı boş olamaz.")
            .GreaterThan(0).WithMessage("Çalışan sayısı 0'dan büyük olmalıdır.");

        RuleFor(cca => cca.Amount)
            .NotEmpty().WithMessage("Kredi tutarı boş olamaz.")
            .GreaterThan(0).WithMessage("Kredi tutarı 0'dan büyük olmalıdır.");

        RuleFor(cca => cca.TermInMonths)
            .NotEmpty().WithMessage("Vade boş olamaz.")
            .GreaterThan(0).WithMessage("Vade 0'dan büyük olmalıdır.");
    }
} 