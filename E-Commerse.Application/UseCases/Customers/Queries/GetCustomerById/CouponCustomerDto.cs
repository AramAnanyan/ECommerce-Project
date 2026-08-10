
namespace ECommerce.Application.UseCases.Customers.Queries.GetCustomerById;

public sealed record CouponCustomerDto
{
    public string Code { get; set; }
    public int Uses { get; set; }
    public bool IsValid { get; set; }
    public int MaxUses { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

}
