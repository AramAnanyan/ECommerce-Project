

namespace ECommerce.Application.UseCases.Customers.Queries.GetCustomerById;

public sealed record AddressDto
{
    public string Country {  get; init; }
    public string City { get; init; }
    public string Street { get; init; } 
    public string PostalCode { get; init; } 
}
