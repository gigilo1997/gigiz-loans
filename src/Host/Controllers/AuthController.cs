using Application.Auth.Commands;
using Application.Auth.Dtos;
using Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

public class AuthController : BaseApiController
{
    private readonly IAuthService _jwtService;

    public AuthController(IAuthService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route(nameof(GenerateToken))]
    public async Task<TokenDto> GenerateToken([FromForm] GenerateTokenCommand request) =>
        await Sender.Send(request);

    [HttpPost]
    [AllowAnonymous]
    [Route(nameof(RefreshToken))]
    public async Task<TokenDto> RefreshToken([FromForm] RefreshTokenCommand request) =>
        await Sender.Send(request);
}
