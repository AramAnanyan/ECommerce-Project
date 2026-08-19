using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.Update;

public sealed class UpdateCouponCommand:IRequest
{
    public int Id { get; init   ; }
    public string Code { get; init; }
    public decimal DiscountPercentage { get; init; }
    public int MaxUses { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public List<int> ProductIds { get; init; }
    public List<int>  AccessCustomersIds { get; init; } 
}
