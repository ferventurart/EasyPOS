using MediatR;

namespace Domain.Primitives;

public record DomainEvent(Guid Id) : INotification;