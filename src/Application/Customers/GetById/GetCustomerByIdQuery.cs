using Customers.Common;

namespace Application.Customers.GetById;

public record GetCustomerByIdQuery(Guid Id) : IRequest<ErrorOr<CustomerResponse>>;