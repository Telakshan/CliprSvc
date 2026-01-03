using Clipr.Modules.Upload.Domain.Entities;

namespace Clipr.Modules.Upload.Infrastructure.Contracts.Persistence;

public interface IUserRepository: IAsyncRepository<User, Guid>
{
}
