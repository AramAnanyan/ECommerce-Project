using MediatR;

namespace ECommerce.Application.UseCases.Products.Commands.Create;

public sealed record CreateProductCommand:IRequest
{
    public Domain.Enums.ProductCategory CategoryId { get; init; }
    public Domain.Enums.Currency CurrencyId { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
}
