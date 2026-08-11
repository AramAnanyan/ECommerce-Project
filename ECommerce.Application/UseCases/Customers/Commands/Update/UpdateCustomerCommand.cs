using MediatR;

namespace ECommerce.Application.UseCases.Customers.Commands.Update;

public sealed record UpdateCustomerCommand:IRequest
{
    public int Id { get; init; }
    public string FullName { get; init; }
    public string EmailAddress { get; init; } 
    public string PhoneNumber { get; init; }
}
