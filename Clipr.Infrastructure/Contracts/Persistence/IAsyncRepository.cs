using Clipr.Domain.Common;

namespace Clipr.Infrastructure.Contracts.Persistence;

public interface IAsyncRepository<T, TId> where T : EntityBase<TId>
{
    Task<T> GetByIdAsync(TId id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
