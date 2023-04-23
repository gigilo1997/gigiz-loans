using Application.Auth.Dtos;
using Application.Common.Abstractions;
using Domain.Auth;
using Shared.Common;

namespace Application.Auth.Commands;

public record RefreshTokenCommand(string Token, string RefreshToken) : ICommand<TokenDto>;

public class RefreshTokenCommandHandler : ICommandHandler<RefreshTokenCommand, TokenDto>
{
    private readonly IAuthService _authService;

    public RefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ValueResult<TokenDto>> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _authService.RefreshTokenAsync(request.Token, request.RefreshToken);

        if (result.IsSuccess)
            return new TokenDto(result.Value!.Token, result.Value.RefreshToken, result.Value.TokenExpiresAtUtc, result.Value.RefreshTokenExpiresAtUtc);

        return Failure.Create(result.ErrorMessages);
    }
}
