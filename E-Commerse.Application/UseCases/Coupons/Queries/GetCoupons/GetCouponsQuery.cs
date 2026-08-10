using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Queries.GetCoupons;

public record GetCouponsQuery(
    int PageNumber = 1,
    int PageSize = 10
) : IRequest<PagedResult<CouponDto>>;
