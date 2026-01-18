using Clipr.Common.Domain.Abstractions;

namespace Clipr.Modules.User.Infrastructure.User;

public interface IUserRepository: IAsyncRepository<Domain.Entities.User, Guid>
{
    Task<Domain.Entities.User> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
