using MediatR;

namespace ECommerce.Application.UseCases.Payments.Commands.Update;

public sealed record UpdatePaymentCommand:IRequest
{
    public int Id { get; init; }
    public int OrderId { get; init; }
    public decimal AmountPaid { get; init; }
    public Domain.Enums.PaymentMethod PaymentMethodId { get; init; }
    public Domain.Enums.PaymentStatus StatusId { get; init; }
}
