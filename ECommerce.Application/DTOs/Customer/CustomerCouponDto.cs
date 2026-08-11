namespace ECommerce.Application.DTOs.Customer;

public sealed record CustomerCouponDto
{
    public string Code { get; set; }
    public int Uses { get; set; }
    public bool IsValid { get; set; }
    public int MaxUses { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
