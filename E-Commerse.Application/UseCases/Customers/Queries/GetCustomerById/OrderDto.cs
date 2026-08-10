
namespace ECommerce.Application.UseCases.Customers.Queries.GetCustomerById;

public sealed record OrderDto
{
    public int OrderId { get; init; }
    public DateTime CreatedAt { get; init; }
    public string Status { get; init; }
}
