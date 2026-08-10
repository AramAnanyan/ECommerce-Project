namespace ECommerce.Application.UseCases.Coupons.Queries.GetCoupons;

public sealed record CouponDto
{
    public int Id { get; init; }
    public string Code { get; init; }
    public decimal DiscountPercentage { get; init; }
    public int MaxUses { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public List<ProductDto> CouponProducts { get; init; }
}
