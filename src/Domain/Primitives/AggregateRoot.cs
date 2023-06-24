namespace Domain.Primitives;

public abstract class AggregateRoot 
{
    private readonly List<DomainEvent> _domainEvents = new();

    public ICollection<DomainEvent> GetDomainEvents() => _domainEvents;

    protected void Raise(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}