using Clipr.Domain.Entities;

namespace Clipr.Infrastructure.Contracts.Persistence;

public interface IUserRepository: IAsyncRepository<User, Guid>
{
}
