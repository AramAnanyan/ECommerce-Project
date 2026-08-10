
namespace ECommerce.Application.UseCases.Coupons.Queries.GetCoupons;

public sealed record ProductDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Category {  get; init; }
}
