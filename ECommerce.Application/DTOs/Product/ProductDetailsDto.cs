namespace ECommerce.Application.DTOs.Product;

public sealed class ProductDetailsDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Category {  get; init; }
    public string ParentCategory { get; init; }
    public string Currency {  get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public List<string> AccessCountries {  get; init; }
    public List<ProductReviewDto> Reviews {  get; init; }
}
