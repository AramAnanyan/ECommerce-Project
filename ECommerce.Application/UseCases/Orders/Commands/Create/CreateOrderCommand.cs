using ECommerce.Application.DTOs.Order;
using MediatR;

namespace ECommerce.Application.UseCases.Orders.Commands.Create;

public record CreateOrderCommand : IRequest<int>
{
    public int CustomerId {  get; init; }
    public int AddressId {  get; init; }
    public Domain.Enums.OrderStatus StatusId {  get; init; }
    public string CouponCode {  get; init; }
    public List<RequestOrderItemDto> Items {  get; init; }
}