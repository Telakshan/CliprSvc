using Clipr.Domain.Common;
using Clipr.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clipr.Infrastructure.Persistence;

public class CliprDbContext(DbContextOptions<CliprDbContext> options) : DbContext(options)
{
    public DbSet<Video> Videos { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
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
}
