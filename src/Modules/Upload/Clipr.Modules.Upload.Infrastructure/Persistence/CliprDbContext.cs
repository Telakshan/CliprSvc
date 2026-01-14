using Clipr.Common.Domain.Abstractions;
using Clipr.Modules.Upload.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Clipr.Modules.Upload.Infrastructure.Persistence;

public class CliprDbContext(DbContextOptions<CliprDbContext> options) : DbContext(options)
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (EntityEntry<IAuditableEntity> entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.CreatedBy = "testUser";
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    public DbSet<Video> Videos => Set<Video>();
    public DbSet<User.Domain.Entities.User> Users => Set<User.Domain.Entities.User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User.Domain.Entities.User>();

        base.OnModelCreating(modelBuilder);
    }
}
