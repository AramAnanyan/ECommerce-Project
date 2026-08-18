
using ECommerce.Application.DTOs.Payment;
using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Payments.Queries.GetById;

internal sealed class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDto>
{
    private readonly IPaymentRepository _paymentRepository;
    public GetPaymentByIdQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<PaymentDto> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id,false,cancellationToken);
        return new PaymentDto
        {
            Id = payment.Id,
            OrderId = payment.OrderId,
            AmountPaid = payment.AmountPaid,
            PaymentMethod = payment.PaymentMethod.Name,
            Status = payment.Status.Name,
            CreatedAt = payment.CreatedAt
        };
    }
}
