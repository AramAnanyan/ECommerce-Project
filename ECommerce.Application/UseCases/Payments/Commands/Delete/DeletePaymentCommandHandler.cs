using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Payments.Commands.Delete;

internal sealed class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeletePaymentCommandHandler(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        await _paymentRepository.DeleteByIdAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
