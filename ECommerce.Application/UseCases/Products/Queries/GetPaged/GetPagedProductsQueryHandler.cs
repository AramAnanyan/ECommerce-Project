using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Products.Queries.GetPaged;

internal sealed class GetPagedProductsQueryHandler : IRequestHandler<GetPagedProductsQuery, PagedResult<ProductDetailsDto>>
{
    private readonly IProductRepository _productRepository;
    public GetPagedProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PagedResult<ProductDetailsDto>> Handle(GetPagedProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        var pagedResult = new PagedResult<ProductDetailsDto>(products.Items.Select(product => new ProductDetailsDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            Category = product.Category.Name,
            ParentCategory = product.Category.ParentCategory.Name,
            Currency = product.Currency.Name,
            AccessCountries = product.CountryAccesses.Select(x => x.Country.Name).ToList(),
            Reviews = product.Reviews.Select(x => new ProductReviewDto
            {
                CustomerFullName = x.Customer.FullName,
                ProductName = x.Product.Name,
                Rating = x.Rating,
                Comment = x.Comment
            }).ToList()
        }).ToList(), products.TotalCount, products.PageNumber, products.PageSize);
        return pagedResult;
    }
}
