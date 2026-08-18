using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.Update;

internal sealed class UpdateCouponCommandHandler : IRequestHandler<UpdateCouponCommand>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCouponCommandHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork)
    {
        _couponRepository = couponRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
    {
        var coupon = await _couponRepository.GetByIdAsync(request.Id,true, cancellationToken);
        var distinctProductIds = request.ProductIds.Distinct().ToList();
        var distinctAccessCustomerIds = request.AccessCustomersIds.Distinct().ToList();
        coupon.Update(
                request.Code,
                request.DiscountPercentage,
                request.MaxUses,
                request.StartDate,
                request.EndDate,
                distinctProductIds,
                distinctAccessCustomerIds
            );
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
