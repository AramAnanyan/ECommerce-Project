using ECommerce.Application.DTOs.Order;
using MediatR;

namespace ECommerce.Application.UseCases.Orders.Queries.GetById;

public record GetOrderByIdQuery : IRequest<OrderDetailsDto>
{
    public int Id { get; init; }
}