namespace ECommerce.Application.DTOs.Customer;

public sealed record CustomerAddressDto
{
    public string Country {  get; init; }
    public string City { get; init; }
    public string Street { get; init; } 
    public string PostalCode { get; init; } 
}
