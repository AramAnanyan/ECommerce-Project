using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Payments.Commands.AddPayment;

internal sealed class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AddPaymentCommandHandler(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = Payment.Create(request.orderId,request.amountPaid,request.paymentMethodId,request.statusId,request.createdAt);

        await _paymentRepository.InsertAsync(payment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
