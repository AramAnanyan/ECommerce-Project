using MediatR;

namespace ECommerce.Application.UseCases.Products.Commands.Update;

public sealed record UpdateProductCommand:IRequest
{
    public int Id {  get; set; }
    public Domain.Enums.ProductCategory CategoryId { get; set; }
    public Domain.Enums.Currency CurrencyId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
