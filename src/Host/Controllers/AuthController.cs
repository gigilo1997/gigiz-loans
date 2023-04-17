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
    public async Task<AuthContracts.TokenResponse> GenerateToken([FromBody] AuthContracts.GenerateTokenRequest request) =>
        await _jwtService.GenerateTokenAsync(request);

    [HttpPost]
    [AllowAnonymous]
    [Route(nameof(RefreshToken))]
    public async Task<AuthContracts.TokenResponse> RefreshToken([FromBody] AuthContracts.RefreshTokenRequest request) =>
        await _jwtService.RefreshTokenAsync(request);
}
