namespace ECommerce.Application.UseCases.Products.Queries.GetProductById;

public sealed class ReviewDto
{
    public string CustomerFullName { get; init; }
    public string ProductName { get; init; }
    public byte Rating { get; init; }
    public string Comment { get; init; }
}
