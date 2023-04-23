using Application.Common.Abstractions;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Common;

namespace Application.Loans.Commands;

public record DeclineLoanCommand(Guid LoanId) : ICommand<Guid>;

public class DeclineLoanCommandHandler : ICommandHandler<DeclineLoanCommand, Guid>
{
    private readonly IRepository<UserLoan> _loanRepository;

    public DeclineLoanCommandHandler(IRepository<UserLoan> loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<ValueResult<Guid>> Handle(DeclineLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.FindByIdAsync(request.LoanId);

        if (loan is null)
            return Failure.Create("Loan does not exist");

        var result = loan.Decline();

        await _loanRepository.UpdateAsync(loan, true, cancellationToken);

        return result.IsSuccess
            ? loan.Id
            : Failure.Create(result.ErrorMessages);
    }
}
