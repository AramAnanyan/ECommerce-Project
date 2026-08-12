namespace ECommerce.Application.DTOs.Order;

public record RequestOrderItemDto
{
    public int ProductId {  get; init; }
    public int Quantity { get; init; }
}
