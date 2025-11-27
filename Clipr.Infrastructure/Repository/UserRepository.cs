using Clipr.Domain.Entities;
using Clipr.Infrastructure.Contracts.Persistence;
using Clipr.Infrastructure.Persistence;

namespace Clipr.Infrastructure.Repository;

public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(CliprDbContext dbContext) : base(dbContext)
    {
    }
}
