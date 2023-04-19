using Domain.Enums;
using Domain.ValueObjects;

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

    public void Process()
    {
        Status = LoanStatus.Processing;
    }

    public void Accept()
    {
        DateTime now = DateTime.UtcNow;

        Status = LoanStatus.Accepted;
        LoanStartDate = now;
        LoanEndDate = now
            .AddYears(LoanPeriod.Years)
            .AddMonths(LoanPeriod.Months)
            .AddDays(LoanPeriod.Days);
    }

    public void Decline()
    {
        Status = LoanStatus.Declined;
    }
}
