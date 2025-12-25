namespace Clipr.Modules.Upload.Domain.Abstractions;
public interface IDomainEvent
{
    Guid Id { get; }
    DateTime OccuredOnUtc { get; }
}

