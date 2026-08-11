using ECommerce.Application.DTOs.Order;
using MediatR;

namespace ECommerce.Application.UseCases.Orders.Commands.Create;

public record CreateOrderCommand(
    int CustomerId,
    int AddressId,
    int StatusId,
    string CouponCode, 
    List<CreateOrderItemDto> Items
) : IRequest<int>;