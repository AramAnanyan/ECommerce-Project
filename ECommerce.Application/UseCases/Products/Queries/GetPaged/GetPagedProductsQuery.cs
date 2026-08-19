using ECommerce.Application.DTOs.Product;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Products.Queries.GetPaged;

public sealed record GetPagedProductsQuery : IRequest<PagedResult<ProductDetailsDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
