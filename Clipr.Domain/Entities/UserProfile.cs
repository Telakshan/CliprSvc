using Clipr.Domain.Common;

namespace Clipr.Domain.Entities;

public class UserProfile: EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public string DisplayName { get; set; } = null!;
    public string? Bio { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public virtual User? User { get; set; }
}