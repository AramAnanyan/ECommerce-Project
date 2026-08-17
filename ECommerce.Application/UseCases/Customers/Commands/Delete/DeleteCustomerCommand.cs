using MediatR;

namespace ECommerce.Application.UseCases.Customers.Commands.Delete;

public sealed record DeleteCustomerCommand:IRequest
{
    public int Id { get; init; }
}
