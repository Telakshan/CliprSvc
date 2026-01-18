namespace Clipr.Common.Domain.Abstractions;

public abstract class Entity<TId> : IAuditableEntity
{
    public TId Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }

    private readonly List<IDomainEvent> _domainEvents = [];

    protected Entity()
    {
    }

    protected Entity(TId id)
    {
        Id = id;
    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents =>
        _domainEvents.ToList();

    public void ClearDomainEvents() =>
        _domainEvents.Clear();

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
