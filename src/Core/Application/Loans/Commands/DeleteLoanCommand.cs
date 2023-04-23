using Application.Common.Abstractions;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Common;

namespace Application.Loans.Commands;

public record DeleteLoanCommand(Guid LoanId) : ICommand<Guid>;

public class DeleteLoanCommandHandler : ICommandHandler<DeleteLoanCommand, Guid>
{
    private readonly IRepository<UserLoan> _loanRepository;

    public DeleteLoanCommandHandler(IRepository<UserLoan> loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<ValueResult<Guid>> Handle(
        DeleteLoanCommand request,
        CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.FindByIdAsync(request.LoanId);

        if (loan is null)
            return Failure.Create("Loan does not exist");

        await _loanRepository.DeleteAsync(loan, true, cancellationToken);

        return loan.Id;
    }
}
