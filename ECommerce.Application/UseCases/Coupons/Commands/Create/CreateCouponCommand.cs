using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.Create;

public sealed record CreateCouponCommand : IRequest
{
    public string Code { get; set; }
    public decimal DiscountPercentage { get; set; }
    public int MaxUses { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<int> CouponProductIds { get; set; }
    public List<int> AccessCustomersIds { get; set; }
}
