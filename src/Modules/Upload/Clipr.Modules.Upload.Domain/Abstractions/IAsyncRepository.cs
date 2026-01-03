using Clipr.Modules.Upload.Domain.Common;

namespace Clipr.Modules.Upload.Domain.Abstractions;

public interface IAsyncRepository<T, TId> where T : EntityBase<TId>
{
    Task<T> GetByIdAsync(TId id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
