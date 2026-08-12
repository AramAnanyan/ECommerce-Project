using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Payments.Commands.Update;

internal sealed class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdatePaymentCommandHandler(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id,cancellationToken);
        payment.Update(
                request.OrderId,
                request.AmountPaid,
                request.PaymentMethodId,
                request.StatusId
            );
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
