namespace ECommerce.Application.DTOs.Customer;

public sealed record CustomerDetailsDto
{
    public int Id { get; init; }
    public string FullName { get; init; }
    public string EmailAddress { get; init; }
    public string PhoneNumber { get; init; }
    public DateTime CreatedAt { get; init; }
    public List<CustomerAddressDto> Addresses { get; set; }
    public List<CustomerReviewDto> Reviews { get; set; }
    public List<CustomerOrderDto> Orders { get; set; }
    public List<CustomerCouponDto> CustomerCoupons { get; set; }
}
