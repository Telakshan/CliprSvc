using Clipr.Modules.User

namespace ClassLibrary1.User;

public class IUserRepository
{
    Task<> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
