using Clipr.Modules.Upload.Infrastructure.Contracts.Persistence;
using Clipr.Modules.Upload.Infrastructure.Persistence;

namespace Clipr.Modules.Upload.Infrastructure.Repository;

public class UserRepository : RepositoryBase<User.Domain.Entities.User, Guid>, IUserRepository
{
    public UserRepository(CliprDbContext dbContext) : base(dbContext)
    {
    }
}
