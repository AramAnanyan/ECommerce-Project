using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.Create;

public sealed record CreateCouponCommand : IRequest
{
    public string Code { get; init; }
    public decimal DiscountPercentage { get; init; }
    public int MaxUses { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public List<int> CouponProductIds { get; init; }
    public List<int> AccessCustomersIds { get; init; }
}
