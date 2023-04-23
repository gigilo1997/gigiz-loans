using Application.Common.Abstractions;
using Application.Loans.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Common;

namespace Application.Loans.Queries;

public record GetLoansQuery(
    Guid? UserId,
    int Page,
    int Limit) : ICommand<PaginatedList<LoanDto>>;

public class GetLoansQueryHandler : ICommandHandler<GetLoansQuery, PaginatedList<LoanDto>>
{
    private readonly IRepository<UserLoan> _loanRepository;

    public GetLoansQueryHandler(IRepository<UserLoan> loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<ValueResult<PaginatedList<LoanDto>>> Handle(GetLoansQuery request, CancellationToken cancellationToken)
    {
        var result = await _loanRepository.GetPaginatedAsync(
            e => !request.UserId.HasValue || e.UserId == request.UserId,
            m => new LoanDto(m.Id, m.Type, m.Amount, m.Currency, m.LoanPeriod.Years, m.LoanPeriod.Months, m.LoanPeriod.Days, m.Status),
            request.Page,
            request.Limit);

        return result;
    }
}
