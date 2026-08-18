using MediatR;
namespace ECommerce.Application.UseCases.Coupons.Commands.AddCustomerAccess;

public sealed record AddCustomerCouponAccessCommand:IRequest
{
    public int couponId {  get; set; }
    public List<int> CustomerIds { get; set; } = [];
}
