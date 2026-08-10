using MediatR;

namespace ECommerce.Application.UseCases.Payments.Commands.AddPayment;

public sealed record AddPaymentCommand(int orderId, decimal amountPaid, int paymentMethodId, int statusId, DateTime? createdAt) : IRequest;
