using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Application.Customers.Create;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Guid>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Guid>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
        {
            return Error.Validation("Customer.PhoneNumber", "Phone number has not valid format.");
        }

        if (Address.Create(command.Country, command.Line1, command.Line2, command.City,
                    command.State, command.ZipCode) is not Address address)
        {
            return Error.Validation("Customer.Address", "Address is not valid.");
        }

        var customer = new Customer(
            new CustomerId(Guid.NewGuid()),
            command.Name,
            command.LastName,
            command.Email,
            phoneNumber,
            address,
            true
        );

        _customerRepository.Add(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return customer.Id.Value;
    }
}
