using MediatR;

namespace ECommerce.Application.UseCases.Orders.Commands.Delete;

public sealed record DeleteOrderCommand:IRequest
{
    public int Id { get; init; }
}
