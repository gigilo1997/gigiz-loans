using Application.Common.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;
using Shared.Common;

namespace Application.Loans.Commands;

public record EditLoanCommand(
    Guid Id,
    LoanType Type,
    decimal Amount,
    Currency Currency,
    int DurationDays,
    int DurationMonths,
    int DurationYears) : ICommand<Guid>;

public class EditLoanCommandHandler : ICommandHandler<EditLoanCommand, Guid>
{
    private readonly IRepository<UserLoan> _loanRepository;

    public EditLoanCommandHandler(IRepository<UserLoan> loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<ValueResult<Guid>> Handle(
        EditLoanCommand request,
        CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.FindByIdAsync(request.Id);

        if (loan is null)
            return Failure.Create("Loan does not exist!");

        var result = loan.Edit(
            request.Type,
            request.Amount,
            request.Currency,
            new LoanPeriod(
                request.DurationYears,
                request.DurationMonths,
                request.DurationDays));

        if (!result.IsSuccess)
            return Failure.Create(result.ErrorMessages);

        await _loanRepository.UpdateAsync(loan, true, cancellationToken);

        return loan.Id;
    }
}
