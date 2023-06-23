namespace Application.Customers.Delete;

public record DeleteCustomerCommand(Guid Id) : IRequest<ErrorOr<Unit>>;