using Application.Loans.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

public class LoanController : BaseApiController
{
    [HttpPost]
    [Route(nameof(CreateLoan))]
    public async Task CreateLoan([FromBody] CreateLoanCommand command) => await Sender.Send(command);
}
