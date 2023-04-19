using Application.Common.Abstractions;
using Domain.Auth;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;
using Shared.Common;

namespace Application.Loans.Commands;

public record CreateLoanCommand(
    LoanType Type,
    decimal Amount,
    Currency Currency,
    int DurationDays,
    int DurationMonths,
    int DurationYears) : ICommand;

public class CreateLoanCommandHandler : ICommandHandler<CreateLoanCommand>
{
    private readonly ICurrentUser _currentUser;
    private readonly IRepository<UserLoan> _userLoanRepository;

    public CreateLoanCommandHandler(
        ICurrentUser currentUser,
        IRepository<UserLoan> userLoanRepository)
    {
        _currentUser = currentUser;
        _userLoanRepository = userLoanRepository;
    }

    public async Task<VoidResult> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _currentUser.GetUserId()!.Value;

        var loan = UserLoan.Create(
            currentUserId,
            request.Type,
            request.Amount,
            request.Currency,
            new LoanPeriod(request.DurationDays, request.DurationMonths, request.DurationYears));

        await _userLoanRepository.AddAsync(loan, true, cancellationToken);

        return VoidResult.Success();
    }
}
