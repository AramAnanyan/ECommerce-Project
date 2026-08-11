

using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.Create;

public sealed record CreateCouponCommand(string Code, decimal DiscountPercentage, int MaxUses, DateTime StartDate, DateTime EndDate, List<int> CouponProductIds):IRequest;
