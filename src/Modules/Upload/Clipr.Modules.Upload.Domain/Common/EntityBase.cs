namespace Clipr.Modules.Upload.Domain.Common;

public abstract class EntityBase<TId> : IAuditableEntity
{
    public TId Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
}
