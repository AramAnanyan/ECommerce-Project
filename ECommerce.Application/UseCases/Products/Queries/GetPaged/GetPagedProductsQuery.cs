using ECommerce.Application.DTOs.Product;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Products.Queries.GetPaged;

public sealed record GetPagedProductsQuery : IRequest<PagedResult<ProductDetailsDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
