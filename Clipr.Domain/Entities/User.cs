namespace Clipr.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public virtual IEnumerable<Video> Videos { get; set; } = [];
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
    //public virtual ICollection<PlayList> PlayLists { get; set; }

}
