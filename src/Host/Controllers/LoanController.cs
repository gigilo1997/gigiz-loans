using Application.Loans.Commands;
using Application.Loans.Dtos;
using Application.Loans.Queries;
using Microsoft.AspNetCore.Mvc;
using Shared.Common;

namespace Host.Controllers;

public class LoanController : BaseApiController
{
    [HttpPost]
    [Route(nameof(CreateLoan))]
    public async Task<Guid> CreateLoan([FromForm] CreateLoanCommand command) =>
        await Sender.Send(command);

    [HttpPut]
    [Route(nameof(EditLoan))]
    public async Task<Guid> EditLoan([FromForm] EditLoanCommand command) =>
        await Sender.Send(command);

    [HttpPut]
    [Route($"{nameof(AcceptLoan)}/{{id}}")]
    public async Task<Guid> AcceptLoan([FromRoute] Guid id) =>
        await Sender.Send(new AcceptLoanCommand(id));

    [HttpPut]
    [Route($"{nameof(DeclineLoan)}/{{id}}")]
    public async Task<Guid> DeclineLoan([FromRoute] Guid id) =>
        await Sender.Send(new DeclineLoanCommand(id));

    [HttpDelete]
    [Route($"{nameof(DeleteLoan)}/{{id}}")]
    public async Task<Guid> DeleteLoan([FromRoute] Guid id) =>
        await Sender.Send(new DeleteLoanCommand(id));

    [HttpGet]
    [Route(nameof(GetLoans))]
    public async Task<PaginatedList<LoanDto>> GetLoans([FromQuery] GetLoansQuery query) =>
        await Sender.Send(query);
}
