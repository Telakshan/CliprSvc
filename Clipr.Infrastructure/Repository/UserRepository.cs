using Clipr.Infrastructure.Contracts.Persistence;
using Clipr.Infrastructure.Persistence;
using Clipr.Modules.Upload.Domain.Entities;

namespace Clipr.Infrastructure.Repository;

public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(CliprDbContext dbContext) : base(dbContext)
    {
    }
}
