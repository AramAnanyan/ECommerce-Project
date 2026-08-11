using ECommerce.Application.DTOs.Coupon;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Queries.GetPaged;

internal sealed class GetPagedCouponsQueryHandler:IRequestHandler<GetPagedCouponsQuery,PagedResult<CouponDto>>
{
    private readonly ICouponRepository _couponRepository;
    public GetPagedCouponsQueryHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork)
    {
        _couponRepository = couponRepository;
    }

    public async Task<PagedResult<CouponDto>> Handle(GetPagedCouponsQuery request, CancellationToken cancellationToken)
    {
        var coupons = await _couponRepository.GetPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        var paged_result = new PagedResult<CouponDto>(coupons.Items.Select(x => new CouponDto
        {
            Id = x.Id,
            Code = x.Code,
            DiscountPercentage = x.DiscountPercentage,
            MaxUses = x.MaxUses,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            CouponProducts = x.CouponProducts.Select(y => new CouponProductDto
            {
                Id = y.ProductId,
                Name = y.Product.Name,
                Category = y.Product.Category.Name
            }).ToList()
        }).ToList(),coupons.TotalCount, request.PageNumber,request.PageSize);

        return paged_result;
    }
}
