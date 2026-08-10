using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.AddCustomerCoupon;

internal sealed class AddCustomerCouponCommandHandler : IRequestHandler<AddCustomerCouponCommand>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AddCustomerCouponCommandHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork)
    {
        _couponRepository = couponRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddCustomerCouponCommand request, CancellationToken cancellationToken)
    {
        var coupon = await _couponRepository.GetByIdAsync(request.couponId, cancellationToken);
        if (coupon == null)
        {
            throw new Exception("No coupon with such Id");
        }
        var existingIds = coupon.CouponCustomers.Select(cc => cc.CustomerId).ToHashSet();

        var newCouponCustomers = request.CustomerIds
            .Distinct()
            .Where(id => !existingIds.Contains(id))
            .Select(customerId => new CouponCustomer
            {
                CouponId = request.couponId,
                CustomerId = customerId
            });
        foreach (var item in newCouponCustomers)
        {
            coupon.CouponCustomers.Add(item);
        }
        await _unitOfWork.SaveChangesAsync();
    }
}
