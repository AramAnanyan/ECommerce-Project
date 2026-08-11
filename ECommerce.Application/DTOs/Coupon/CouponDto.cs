namespace ECommerce.Application.DTOs.Coupon;

public sealed record CouponDto
{
    public int Id { get; init; }
    public string Code { get; init; }
    public decimal DiscountPercentage { get; init; }
    public int MaxUses { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public List<CouponProductDto> CouponProducts { get; init; }
}
