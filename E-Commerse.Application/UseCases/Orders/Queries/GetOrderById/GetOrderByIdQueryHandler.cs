using ECommerce.Application.Interfaces;
using ECommerce.Application.Orders.Queries.GetOrderById;
using MediatR;

namespace ECommerce.Application.UseCases.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDetailsDto>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDetailsDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        return new OrderDetailsDto
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            StatusName = order.Status.Name,
            CreatedAt = order.CreatedAt,
            TotalAmount = order.OrderItems.Sum(x => (x.Price * x.Quantity) - x.Discount),
            Items = order.OrderItems.Select(x => new OrderItemDto
            {
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                Discount = x.Discount,
                TotalPrice = x.Quantity * (x.Price - x.Discount)
            }).ToList()
        };
    }
}
