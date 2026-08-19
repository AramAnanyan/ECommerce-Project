using MediatR;

namespace ECommerce.Application.UseCases.Payments.Commands.Create;

public sealed record CreatePaymentCommand : IRequest
{
    public int OrderId { get; init; }
    public decimal AmountPaid { get; init; }
    public Domain.Enums.PaymentMethod PaymentMethodId { get; init; }
    public Domain.Enums.PaymentStatus StatusId { get; init; }
    public DateTime? CreatedAt { get; init; }
} 
