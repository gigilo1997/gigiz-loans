using Domain.Enums;

namespace Application.Loans.Dtos;

public record LoanDto(
    Guid Id,
    LoanType Type,
    decimal Amount,
    Currency Currency,
    int LoanYears,
    int LoanMonths,
    int LoanDays,
    LoanStatus Status);
