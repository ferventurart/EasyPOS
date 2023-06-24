using Application.Customers.Create;
using Domain.Customers;
using Domain.Primitives;

namespace Application.Customers.UnitTests.Create;

public class CreateCustomerCommandHandlerUnitTests
{
    private readonly Mock<ICustomerRepository> _mockCustomerRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly CreateCustomerCommandHandler _handler;

    public CreateCustomerCommandHandlerUnitTests()
    {
        _mockCustomerRepository = new Mock<ICustomerRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        
        _handler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public void HandleCreateCustomer_WhenPhoneNumberHasBadFormat_ShouldReturnValidationError()
    {

    }
}