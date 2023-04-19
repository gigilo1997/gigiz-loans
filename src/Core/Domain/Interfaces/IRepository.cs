namespace Domain.Interfaces;

public interface IRepository<T>
    where T : class
{
    Task AddAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default);
}
