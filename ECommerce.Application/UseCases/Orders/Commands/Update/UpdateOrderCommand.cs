using ECommerce.Application.DTOs.Order;
using MediatR;

namespace ECommerce.Application.UseCases.Orders.Commands.Update;

public sealed record UpdateOrderCommand:IRequest
{
    public int Id { get; set; }
    public Domain.Enums.OrderStatus StatusId { get; set; }
    public int AddressId { get; set; }
    public string CouponCode {  get; set; }
    public List<RequestOrderItemDto> Items { get; set; }
}
