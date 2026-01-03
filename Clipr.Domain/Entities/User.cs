using Clipr.Domain.Common;

namespace Clipr.Domain.Entities;

public class User: EntityBase<Guid>
{
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Username { get; set; } = null!;
    public virtual IEnumerable<Video> Videos { get; set; } = [];
    public virtual UserProfile? UserProfile { get; set; }

    //public virtual ICollection<PlayList> PlayLists { get; set; }

}
