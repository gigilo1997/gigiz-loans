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
    public async Task<bool> CreateLoan([FromForm] CreateLoanCommand command) =>
        await Sender.Send(command);

    [HttpPost]
    [Route(nameof(EditLoan))]
    public async Task<bool> EditLoan([FromForm] EditLoanCommand command) =>
        await Sender.Send(command);

    [HttpGet]
    [Route(nameof(GetLoans))]
    public async Task<PaginatedList<LoanDto>> GetLoans([FromQuery] GetLoansQuery query) =>
        await Sender.Send(query);
}
