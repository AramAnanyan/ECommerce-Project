using MediatR;

namespace ECommerce.Application.UseCases.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(int Id) : IRequest<OrderDetailsDto>;