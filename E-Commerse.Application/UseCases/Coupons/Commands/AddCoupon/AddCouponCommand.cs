

using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.AddCoupon;

public sealed record AddCouponCommand(string Code, decimal DiscountPercentage, int MaxUses, DateTime StartDate, DateTime EndDate, List<int> CouponProductIds):IRequest;
