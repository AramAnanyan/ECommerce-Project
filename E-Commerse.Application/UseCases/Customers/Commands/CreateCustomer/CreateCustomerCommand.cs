using MediatR;

namespace ECommerce.Application.UseCases.Customers.Commands.CreateCustomer;

public sealed record CreateCustomerCommand:IRequest
{
    public string FullName { get; init; }
    public string EmailAddress { get; init; }
    public string PhoneNumber { get; init; }
}
