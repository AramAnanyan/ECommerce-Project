using MediatR;

namespace ECommerce.Application.UseCases.Customers.Commands.AddAddress;

public sealed record AddCustomerAddressCommand:IRequest
{
    public int CustomerId { get; init; }
    public int CityId {  get; init; }
    public string Street { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
}
