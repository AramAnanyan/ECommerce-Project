namespace ECommerce.Application.Customers.Queries.GetCustomerById;

public sealed class ReviewDto
{
    public int ProductId { get; init; }
    public byte Rating { get; init; }
    public string Comment { get; init; }
}
