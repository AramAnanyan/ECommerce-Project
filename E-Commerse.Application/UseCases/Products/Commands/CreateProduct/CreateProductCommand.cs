using MediatR;

namespace ECommerce.Application.UseCases.Products.Commands.CreateProduct;

public sealed record CreateProductCommand:IRequest
{
    public int CategoryId { get; set; }
    public int CurrencyId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
