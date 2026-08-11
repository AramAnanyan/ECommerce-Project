using MediatR;

namespace ECommerce.Application.UseCases.Payments.Commands.Create;

public sealed record CreatePaymentCommand(int orderId, decimal amountPaid, int paymentMethodId, int statusId, DateTime? createdAt) : IRequest;
