using MediatR;

namespace ECommerce.Application.UseCases.Products.Commands.Update;

public sealed record UpdateProductCommand:IRequest
{
    public int Id {  get; init; }
    public Domain.Enums.ProductCategory CategoryId { get; init; }
    public Domain.Enums.Currency CurrencyId { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
}
