using Clipr.Modules.Upload.Domain.Common;

namespace Clipr.Modules.Interaction.Domain;

public class Comment: EntityBase<Guid>
{
    public Guid CommentId { get; set; }
    public Guid VideoId { get; set; }
    public Guid AuthorId { get; set; }
    public string Content { get; set; }
}
