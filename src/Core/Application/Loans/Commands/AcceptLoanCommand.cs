using Application.Common.Abstractions;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Common;

namespace Application.Loans.Commands;

public record AcceptLoanCommand(Guid LoanId) : ICommand<Guid>;

public class AcceptLoanCommandHandler : ICommandHandler<AcceptLoanCommand, Guid>
{
    private readonly IRepository<UserLoan> _loanRepository;

    public AcceptLoanCommandHandler(IRepository<UserLoan> loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<ValueResult<Guid>> Handle(
        AcceptLoanCommand request,
        CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.FindByIdAsync(request.LoanId);

        if (loan is null)
            return Failure.Create("Loan not found");

        var result = loan.Accept();

        if (!result.IsSuccess)
            return Failure.Create(result.ErrorMessages);

        await _loanRepository.UpdateAsync(loan, true, cancellationToken);

        return loan.Id;
    }
}
