using FluentValidation.Results;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions;

public class ValidationException : Exception
{
    public IEnumerable<ValidationFailure> Errors { get; }

    public ValidationException(IEnumerable<ValidationFailure> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }

    private static string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
    {
        return string.Join(Environment.NewLine, errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}"));
    }
} 