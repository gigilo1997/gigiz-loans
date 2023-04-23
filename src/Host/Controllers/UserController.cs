using Application.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

public class UserController : BaseApiController
{
    [HttpPost]
    [AllowAnonymous]
    [Route(nameof(RegisterUser))]
    public async Task<Guid> RegisterUser([FromForm] RegisterUserCommand request) => await Sender.Send(request);
}
