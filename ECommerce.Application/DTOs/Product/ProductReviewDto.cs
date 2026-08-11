namespace ECommerce.Application.DTOs.Product;

public sealed class ProductReviewDto
{
    public string CustomerFullName { get; init; }
    public string ProductName { get; init; }
    public byte Rating { get; init; }
    public string Comment { get; init; }
}
