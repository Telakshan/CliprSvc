using Clipr.Modules.Upload.Domain.Common;

namespace Clipr.Modules.Interaction.Domain;

public class Like: EntityBase<Guid>
{
    public Guid LikeId { get; set; }
    public Guid VideoId { get; set; }
    public Guid UserId { get; set; }
    public int Kind { get; set; }
}
