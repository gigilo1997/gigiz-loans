using Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

public class AuthController : BaseApiController
{
    private readonly IJwtService _jwtService;

    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route(nameof(GenerateToken))]
    public async Task<JwtContracts.TokenResponse> GenerateToken([FromBody] JwtContracts.GenerateTokenRequest request) =>
        await _jwtService.GenerateTokenAsync(request);

    [HttpPost]
    [AllowAnonymous]
    [Route(nameof(RefreshToken))]
    public async Task<JwtContracts.TokenResponse> RefreshToken([FromBody] JwtContracts.RefreshTokenRequest request) =>
        await _jwtService.RefreshTokenAsync(request);
}
