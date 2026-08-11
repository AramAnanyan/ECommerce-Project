using MediatR;
namespace ECommerce.Application.UseCases.Coupons.Commands.AddCustomerAccess;

public sealed record AddCustomerCouponAccessCommand(int couponId, List<int> CustomerIds):IRequest;
