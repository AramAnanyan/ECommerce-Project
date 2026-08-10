using MediatR;

namespace ECommerce.Application.UseCases.Orders.Commands.CreateOrder;

public record CreateOrderCommand(
    int CustomerId,
    int AddressId,
    int StatusId,
    string CouponCode, 
    List<CreateOrderItemDto> Items
) : IRequest<int>;