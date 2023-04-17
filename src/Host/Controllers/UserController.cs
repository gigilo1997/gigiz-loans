using Application.User.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

public class UserController : BaseApiController
{
    [HttpPost]
    [AllowAnonymous]
    [Route(nameof(RegisterUser))]
    public async Task RegisterUser([FromBody] RegisterUserCommand request) => await Sender.Send(request);
}
