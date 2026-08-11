using ECommerce.Application.DTOs.Coupon;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Queries.GetPaged;

public record GetPagedCouponsQuery(
    int PageNumber = 1,
    int PageSize = 10
) : IRequest<PagedResult<CouponDto>>;
