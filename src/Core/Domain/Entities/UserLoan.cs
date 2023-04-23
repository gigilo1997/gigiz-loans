using Domain.Enums;
using Domain.ValueObjects;
using Shared.Common;
using Shared.Extensions;

namespace Domain.Entities;

public class UserLoan
{
    private UserLoan()
    {
    }

    public Guid Id { get; private set; } = Guid.Empty;
    public Guid UserId { get; private set; }
    public LoanType Type { get; private set; }
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }
    public LoanStatus Status { get; private set; }
    public LoanPeriod LoanPeriod { get; private set; } = new LoanPeriod(0,0,0);
    public DateTime? LoanStartDate { get; private set; }
    public DateTime? LoanEndDate { get; private set; }

    public static UserLoan Create(
        Guid userId,
        LoanType type,
        decimal amount,
        Currency currency,
        LoanPeriod period)
    {
        return new UserLoan
        {
            UserId = userId,
            Type = type,
            Amount = amount,
            Currency = currency,
            LoanPeriod = period,
            Status = LoanStatus.Sent
        };
    }

    public VoidResult Edit(
        LoanType type,
        decimal amount,
        Currency currency,
        LoanPeriod period)
    {
        if (Status == LoanStatus.Accepted || Status == LoanStatus.Declined)
            return VoidResult.Failure($"Can not edit loan with status {Status.ToEnumString()}");

        Type = type;
        Amount = amount;
        Currency = currency;
        LoanPeriod = period;

        if (LoanStartDate.HasValue)
            return UpdateEndDate();

        return VoidResult.Success();
    }

    public VoidResult Process()
    {
        if (Status != LoanStatus.Sent)
            return VoidResult.Failure($"Can not process loan with status {Status.ToEnumString()}");

        Status = LoanStatus.Processing;

        return VoidResult.Success();
    }

    public VoidResult Accept()
    {
        if (Status != LoanStatus.Processing)
            return VoidResult.Failure($"Can not accept loan with status {Status.ToEnumString()}");

        Status = LoanStatus.Accepted;
        LoanStartDate = DateTime.UtcNow;
        return UpdateEndDate();
    }

    public VoidResult Decline()
    {
        if (Status == LoanStatus.Accepted)
            return VoidResult.Failure($"Can not decline loan with status {Status.ToEnumString()}");

        Status = LoanStatus.Declined;

        return VoidResult.Success();
    }

    private VoidResult UpdateEndDate()
    {
        if (LoanStartDate.HasValue)
            return VoidResult.Failure("Loan start date is not yet set");

        LoanEndDate = LoanStartDate!.Value
            .AddYears(LoanPeriod.Years)
            .AddMonths(LoanPeriod.Months)
            .AddDays(LoanPeriod.Days);

        return VoidResult.Success();
    }
}
