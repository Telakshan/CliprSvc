using Clipr.Modules.Upload.Domain.Entities;
using Clipr.Modules.Upload.Infrastructure.Contracts.Persistence;
using Clipr.Modules.Upload.Infrastructure.Persistence;

namespace Clipr.Modules.Upload.Infrastructure.Repository;

public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(CliprDbContext dbContext) : base(dbContext)
    {
    }
}
