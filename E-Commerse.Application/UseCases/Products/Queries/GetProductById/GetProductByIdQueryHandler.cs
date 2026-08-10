using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Products.Queries.GetProductById;

internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailsDto>
{
    IProductRepository _productRepository;
    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductDetailsDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.id, cancellationToken);

        return new ProductDetailsDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            Category = product.Category.Name,
            ParentCategory = product.Category.ParentCategory.Name,
            Currency = product.Currency.Name,
            AccessCountries = product.CountryAccesses.Select(x=>x.Country.Name).ToList(),
            Reviews = product.Reviews.Select(x=>new ReviewDto
            {
                CustomerFullName = x.Customer.FullName,
                ProductName = x.Product.Name,
                Rating = x.Rating,
                Comment = x.Comment
            }).ToList()
        };
    }
}
