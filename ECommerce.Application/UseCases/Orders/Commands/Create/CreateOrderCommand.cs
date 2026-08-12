using ECommerce.Application.DTOs.Order;
using MediatR;

namespace ECommerce.Application.UseCases.Orders.Commands.Create;

public record CreateOrderCommand : IRequest<int>
{
    public int CustomerId {  get; set; }
    public int AddressId {  get; set; }
    public Domain.Enums.OrderStatus StatusId {  get; set; }
    public string CouponCode {  get; set; }
    public List<RequestOrderItemDto> Items {  get; set; }
}