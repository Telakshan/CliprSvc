using Clipr.Domain.Common;
using Clipr.Infrastructure.Contracts.Persistence;
using Clipr.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clipr.Infrastructure.Repository;

public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
{
    protected readonly CliprDbContext _dbContext;   

    public RepositoryBase(CliprDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T> AddAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);

        return entity ?? throw new Exception("No video found!");
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        var entities = await _dbContext.Set<T>().ToListAsync();   

        return entities;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
