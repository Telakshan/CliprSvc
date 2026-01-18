using Clipr.Common.Domain.Abstractions;

namespace Clipr.Modules.Interaction.Domain;

public class Like: Entity<Guid>
{
    public Guid LikeId { get; set; }
    public Guid VideoId { get; set; }
    public Guid UserId { get; set; }
    public int Kind { get; set; }
}
