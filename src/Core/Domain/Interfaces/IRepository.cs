using Shared.Common;
using System.Linq.Expressions;

namespace Domain.Interfaces;

public interface IRepository<T>
    where T : class
{
    Task<T?> FindByIdAsync(object id);
    Task AddAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default);
    Task<PaginatedList<TResult>> GetPaginatedAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, int pageIndex, int pageSize);
}
