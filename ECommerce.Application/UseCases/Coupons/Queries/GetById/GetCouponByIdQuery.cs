using ECommerce.Application.DTOs.Coupon;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Queries.GetById;

public sealed record GetCouponByIdQuery:IRequest<CouponDto>
{
    public int Id {  get; init; }
}
