using ECommerce.Application.DTOs.Order;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;
namespace ECommerce.Application.UseCases.Orders.Queries.GetPaged;

internal sealed class GetPagedOrdersQueryHandler : IRequestHandler<GetPagedOrdersQuery, PagedResult<OrderDetailsDto>>
{
    private readonly IOrderRepository _orderRepository;
    public GetPagedOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<PagedResult<OrderDetailsDto>> Handle(GetPagedOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetPagedListAsync(request.PageNumber,request.PageSize, cancellationToken);
        var pagedResult = new PagedResult<OrderDetailsDto>(orders.Items.Select(order=>new OrderDetailsDto
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            AddressId = order.AddressId,
            StatusName = order.Status.Name,
            CreatedAt = order.CreatedAt,
            TotalAmount = order.OrderItems.Sum(x => Math.Round(((x.Price * x.Quantity) - x.Discount) / x.Product.Currency.MainRate,2)),
            Items = order.OrderItems.Select(x => new OrderItemDto
            {
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                Discount = x.Discount,
                TotalPrice = Math.Round(((x.Quantity * x.Price) - x.Discount) / x.Product.Currency.MainRate,2)
            }).ToList()
        }).ToList(),
            orders.TotalCount,orders.PageNumber,orders.PageSize);

        return pagedResult;
    }
}
