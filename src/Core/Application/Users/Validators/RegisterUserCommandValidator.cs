using Application.Users.Commands;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Users.Validators;

internal class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(e => e.UserName)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(20);

        RuleFor(e => e.FirstName)
            .NotEmpty();

        RuleFor(e => e.LastName)
            .NotEmpty();

        RuleFor(e => e.PersonalNumber)
            .NotEmpty();

        RuleFor(e => e.Password)
            .MinimumLength(6).WithMessage("Password needs to be longer than 6 characters")
            .MaximumLength(20).WithMessage("Password needs to be smaller than 20 characters")
            .Must(ValidatePassword).WithMessage("Password must contain at least one lowercase, uppercase and digit characters");

        RuleFor(e => e.Password)
            .Equal(e => e.RepeatPassword)
            .WithMessage("Passwords do not match");
    }

    private bool ValidatePassword(string pw)
    {
        var lowercase = new Regex("[a-z]+");
        var uppercase = new Regex("[A-Z]+");
        var digit = new Regex("(\\d)+");

        return lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw);
    }
}
