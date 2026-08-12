using ECommerce.Application.DTOs.Payment;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Payments.Queries.GetPaged;

internal sealed class GetPagedPaymentsQueryHandler : IRequestHandler<GetPagedPaymentsQuery, PagedResult<PaymentDto>>
{
    private readonly IPaymentRepository _paymentRepository;
    public GetPagedPaymentsQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<PagedResult<PaymentDto>> Handle(GetPagedPaymentsQuery request, CancellationToken cancellationToken)
    {
        var payments = await _paymentRepository.GetPagedListAsync(request.PageNumber,request.PageSize, cancellationToken);
        return new PagedResult<PaymentDto>(
                payments.Items.Select(payment=>
                    new PaymentDto
                    {
                        Id = payment.Id,
                        OrderId = payment.OrderId,
                        AmountPaid = payment.AmountPaid,
                        PaymentMethod = payment.PaymentMethod.Name,
                        Status = payment.Status.Name,
                        CreatedAt = payment.CreatedAt
                    }
                ).ToList(),
                payments.TotalCount,
                payments.PageNumber,
                payments.PageSize
            );
    }
}
