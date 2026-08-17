using ECommerce.Application.DTOs.Coupon;
using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Queries.GetById;

internal sealed class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByIdQuery, CouponDto>
{
    private readonly ICouponRepository _couponRepository;
    public GetCouponByIdQueryHandler(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }

    public async Task<CouponDto> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
    {
        var coupon = await _couponRepository.GetByIdAsync(request.Id, cancellationToken);
        return new CouponDto
        {
            Id = coupon.Id,
            Code = coupon.Code,
            DiscountPercentage = coupon.DiscountPercentage,
            MaxUses = coupon.MaxUses,
            StartDate = coupon.StartDate,
            EndDate = coupon.EndDate,
            CouponProducts = coupon.CouponProducts.Select(x=>new CouponProductDto
            {
                Id = x.Id,
                Name = x.Product.Name,
                Category = x.Product.Category.Name
            }).ToList()
        };
    }
}
