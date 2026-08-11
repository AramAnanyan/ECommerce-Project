namespace ECommerce.Application.DTOs.Customer;

public sealed record CustomerOrderDto
{
    public int OrderId { get; init; }
    public DateTime CreatedAt { get; init; }
    public string Status { get; init; }
}
