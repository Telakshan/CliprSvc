using Clipr.Modules.Upload.Domain.Entities;

namespace Clipr.Infrastructure.Contracts.Persistence;

public interface IUserRepository: IAsyncRepository<User, Guid>
{
}
