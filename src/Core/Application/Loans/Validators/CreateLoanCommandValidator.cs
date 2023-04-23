using Application.Loans.Commands;
using FluentValidation;

namespace Application.Loans.Validators;

internal class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
{
    public CreateLoanCommandValidator()
    {
        RuleFor(e => e.Type)
            .IsInEnum()
            .WithMessage("Invalid value");

        RuleFor(e => e.Amount)
            .Must(a => a > 0)
            .WithMessage("Must be a positive number");

        RuleFor(e => e.Currency)
            .IsInEnum()
            .WithMessage("Invalid value");

        RuleFor(e => e.DurationDays)
            .Must(d => d >= 0)
            .WithMessage("Must not be a negative number");

        RuleFor(e => e.DurationMonths)
            .Must(d => d >= 0)
            .WithMessage("Must not be a negative number");

        RuleFor(e => e.DurationYears)
            .Must(d => d >= 0)
            .WithMessage("Must not be a negative number");
    }
}
