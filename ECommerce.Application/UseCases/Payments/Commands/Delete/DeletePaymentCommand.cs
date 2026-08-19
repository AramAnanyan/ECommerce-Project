using MediatR;

namespace ECommerce.Application.UseCases.Payments.Commands.Delete;

public sealed record DeletePaymentCommand:IRequest
{
    public int Id { get; init; }
}
