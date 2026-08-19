using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.Delete;

public sealed record DeleteCouponCommand:IRequest
{
    public int Id { get; init; }
}
