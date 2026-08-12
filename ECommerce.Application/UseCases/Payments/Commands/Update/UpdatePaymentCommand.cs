using MediatR;

namespace ECommerce.Application.UseCases.Payments.Commands.Update;

public sealed record UpdatePaymentCommand:IRequest
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public decimal AmountPaid { get; set; }
    public Domain.Enums.PaymentMethod PaymentMethodId { get; set; }
    public Domain.Enums.PaymentStatus StatusId { get; set; }
}
