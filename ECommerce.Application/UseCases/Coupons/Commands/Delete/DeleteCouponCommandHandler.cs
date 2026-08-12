using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.Delete;

internal sealed class DeleteCouponCommandHandler : IRequestHandler<DeleteCouponCommand>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCouponCommandHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork)
    {
        _couponRepository = couponRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
    {
        await _couponRepository.DeleteByIdAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
