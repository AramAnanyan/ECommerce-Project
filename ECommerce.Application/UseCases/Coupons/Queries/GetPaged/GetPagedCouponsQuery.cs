using ECommerce.Application.DTOs.Coupon;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Queries.GetPaged;

public record GetPagedCouponsQuery : IRequest<PagedResult<CouponDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

