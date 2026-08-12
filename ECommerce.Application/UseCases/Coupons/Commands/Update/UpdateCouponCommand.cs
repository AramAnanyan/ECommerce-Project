using MediatR;

namespace ECommerce.Application.UseCases.Coupons.Commands.Update;

public sealed class UpdateCouponCommand:IRequest
{
    public int Id { get; set; }
    public string Code { get; set; }
    public decimal DiscountPercentage { get; set; }
    public int MaxUses { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<int> ProductIds { get; set; }
    public List<int>  AccessCustomersIds { get; set; } 
}
