using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Queries.GetCoupons;

internal sealed class GetCouponsQueryHandler:IRequestHandler<GetCouponsQuery,PagedResult<CouponDto>>
{
    private readonly ICouponRepository _couponRepository;
    public GetCouponsQueryHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork)
    {
        _couponRepository = couponRepository;
    }

    public async Task<PagedResult<CouponDto>> Handle(GetCouponsQuery request, CancellationToken cancellationToken)
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
            CouponProducts = x.CouponProducts.Select(y => new ProductDto
            {
                Id = y.ProductId,
                Name = y.Product.Name,
                Category = y.Product.Category.Name
            }).ToList()
        }).ToList(),coupons.TotalCount, request.PageNumber,request.PageSize);

        return paged_result;
    }
}
