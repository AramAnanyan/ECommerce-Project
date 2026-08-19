using ECommerce.Application.DTOs.Order;
using MediatR;

namespace ECommerce.Application.UseCases.Orders.Commands.Update;

public sealed record UpdateOrderCommand:IRequest
{
    public int Id { get; init; }
    public Domain.Enums.OrderStatus StatusId { get; init; }
    public int AddressId { get; init; }
    public string CouponCode {  get; init; }
    public List<RequestOrderItemDto> Items { get; init; }
}
