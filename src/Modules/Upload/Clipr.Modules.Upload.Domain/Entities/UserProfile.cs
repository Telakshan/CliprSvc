using Clipr.Common.Domain.Abstractions;

namespace Clipr.Modules.Upload.Domain.Entities;

public class UserProfile: EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public string DisplayName { get; set; } = null!;
    public string? Bio { get; set; }
    public Uri ProfilePictureUrl { get; set; }
}
