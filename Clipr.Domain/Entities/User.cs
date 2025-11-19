using Clipr.Domain.Common;

namespace Clipr.Domain.Entities;

public class User: EntityBase
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Username { get; set; } = null!;
    public virtual IEnumerable<Video> Videos { get; set; } = [];

    //public virtual ICollection<PlayList> PlayLists { get; set; }

}
