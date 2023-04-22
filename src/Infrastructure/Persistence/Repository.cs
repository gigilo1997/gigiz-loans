using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
using System.Linq.Expressions;

namespace Infrastructure.Persistence;

internal class Repository<T> : IRepository<T>
    where T : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppDbContext _context;

    public Repository(
        AppDbContext context,
        IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    private DbSet<T> Table => _context.Set<T>();

    public async Task AddAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        Table.Add(entity);

        if (autoSave)
            await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        Table.Update(entity);

        if (autoSave)
            await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginatedList<TResult>> GetPaginatedAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, int pageIndex, int pageSize)
    {
        var query = Table.Where(predicate);

        int count = await query.CountAsync();

        var items = await Table
            .Where(predicate)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .Select(selector)
            .ToListAsync();

        return new PaginatedList<TResult>(items, count, pageIndex, pageSize);
    }
}
