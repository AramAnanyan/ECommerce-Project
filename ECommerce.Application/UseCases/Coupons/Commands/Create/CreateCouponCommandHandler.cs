using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.Create;

internal sealed class CreateCouponCommandHandler:IRequestHandler<CreateCouponCommand>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCouponCommandHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork)
    {
        _couponRepository = couponRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCouponCommand request, CancellationToken cancellationToken)
    {
        var existing = await _couponRepository.GetByCodeAsync(request.Code,cancellationToken);
        if (existing == null)
        {
            var newCoupon = Coupon.Create(request.Code,request.DiscountPercentage,request.MaxUses,request.StartDate,request.EndDate,request.CouponProductIds);
            await _couponRepository.InsertAsync(newCoupon);
            await _unitOfWork.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Duplicate code");
        }
    }
}
