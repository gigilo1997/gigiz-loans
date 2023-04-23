using Application.Common.Abstractions;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Shared.Common;

namespace Application.Users.Commands;

public record RegisterUserCommand(
    string UserName,
    string Password,
    string RepeatPassword,
    string FirstName,
    string LastName,
    string PersonalNumber,
    DateTime DateOfBirth)
    : ICommand<Guid>;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserManager _userManager;

    public RegisterUserCommandHandler(IUserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task<ValueResult<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = AppUser.Create(
            request.UserName,
            request.FirstName,
            request.LastName,
            request.PersonalNumber,
            request.DateOfBirth);

        var result = await _userManager.CreateWithPasswordAsync(user, request.Password);

        return result.IsSuccess
            ? user.Id
            : Failure.Create(result.ErrorMessages);
    }
}
