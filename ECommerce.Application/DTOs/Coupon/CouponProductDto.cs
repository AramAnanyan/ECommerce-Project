namespace ECommerce.Application.DTOs.Coupon;

public sealed record CouponProductDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Category {  get; init; }
}
