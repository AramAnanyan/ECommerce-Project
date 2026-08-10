using MediatR;
namespace ECommerce.Application.UseCases.Coupons.Commands.AddCustomerCoupon;

public sealed record AddCustomerCouponCommand(int couponId, List<int> CustomerIds):IRequest;
