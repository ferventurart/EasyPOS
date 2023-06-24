using Application.Customers.Create;
using Application.Customers.Update;
using Application.Customers.GetById;
using Application.Customers.Delete;
using Application.Customers.GetAll;

namespace Web.API.Controllers;

[Route("customers")]
public class Customers : ApiController
{
    private readonly ISender _mediator;

    public Customers(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customersResult = await _mediator.Send(new GetAllCustomersQuery());

        return customersResult.Match(
            customers => Ok(customers),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var customerResult = await _mediator.Send(new GetCustomerByIdQuery(id));

        return customerResult.Match(
            customer => Ok(customer),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            customerId => Ok(customerId),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Customer.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            customerId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteCustomerCommand(id));

        return deleteResult.Match(
            customerId => NoContent(),
            errors => Problem(errors)
        );
    }
}