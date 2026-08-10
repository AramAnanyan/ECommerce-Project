namespace ECommerce.Application.UseCases.Customers.Queries.GetCustomerById;

public sealed record ReviewDto
{
    public int ProductId { get; init; }
    public byte Rating { get; init; }
    public string Comment { get; init; }
}
