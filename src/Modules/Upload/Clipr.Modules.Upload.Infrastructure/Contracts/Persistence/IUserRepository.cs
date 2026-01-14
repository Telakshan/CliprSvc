namespace Clipr.Modules.Upload.Infrastructure.Contracts.Persistence;

public interface IUserRepository: IAsyncRepository<User.Domain.Entities.User, Guid>
{
}
