using ECommerce.Application.DTOs.Payment;
using MediatR;

namespace ECommerce.Application.UseCases.Payments.Queries.GetById;

public sealed record GetPaymentByIdQuery: IRequest<PaymentDto>
{
    public int Id { get; init; }
}

