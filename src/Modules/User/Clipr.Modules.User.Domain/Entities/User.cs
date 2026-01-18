using Clipr.Common.Domain.Abstractions;

namespace Clipr.Modules.User.Domain.Entities;

public class User: Entity<Guid>
{
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Username { get; set; } = null!;
}
