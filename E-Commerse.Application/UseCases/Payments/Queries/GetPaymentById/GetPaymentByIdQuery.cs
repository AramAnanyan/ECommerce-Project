

using MediatR;

namespace ECommerce.Application.UseCases.Payments.Queries.GetPaymentById;

public sealed record GetPaymentByIdQuery(int Id) : IRequest<PaymentDto>;

