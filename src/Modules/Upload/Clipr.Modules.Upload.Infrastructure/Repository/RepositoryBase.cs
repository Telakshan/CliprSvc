using Clipr.Common.Domain.Abstractions;
using Clipr.Modules.Upload.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clipr.Modules.Upload.Infrastructure.Repository;

public class RepositoryBase<T, TId> : Contracts.Persistence.IAsyncRepository<T, TId> where T : EntityBase<TId>
{
    protected readonly CliprDbContext _dbContext;   

    public RepositoryBase(CliprDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T> AddAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<T> GetByIdAsync(TId id)
    {
        T? entity = await _dbContext.Set<T>().FindAsync(id).ConfigureAwait(false);

        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with id {id} was not found.");
        }

        return entity;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync().ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        List<T> entities = await _dbContext.Set<T>().ToListAsync().ConfigureAwait(false);   

        return entities;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
    }
}
