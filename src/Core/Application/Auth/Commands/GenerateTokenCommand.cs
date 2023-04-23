using Application.Auth.Dtos;
using Application.Common.Abstractions;
using Domain.Auth;
using Shared.Common;

namespace Application.Auth.Commands;

public record GenerateTokenCommand(string UserName, string Password) : ICommand<TokenDto>;

public class GenerateTokenCommandHandler : ICommandHandler<GenerateTokenCommand, TokenDto>
{
    private readonly IAuthService _authService;

    public GenerateTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ValueResult<TokenDto>> Handle(
        GenerateTokenCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _authService.GenerateTokenAsync(request.UserName, request.Password);

        if (result.IsSuccess)
            return new TokenDto(result.Value!.Token, result.Value.RefreshToken, result.Value.TokenExpiresAtUtc, result.Value.RefreshTokenExpiresAtUtc);

        return Failure.Create(result.ErrorMessages);
    }
}
