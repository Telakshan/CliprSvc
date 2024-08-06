using Clipr.Domain.Common;

namespace Clipr.Infrastructure.Contracts.Persistence;

public interface IAsyncRepository<T> where T : EntityBase
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
