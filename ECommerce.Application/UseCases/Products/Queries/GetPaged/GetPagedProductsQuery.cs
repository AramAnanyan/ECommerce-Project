using ECommerce.Application.DTOs.Product;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Products.Queries.GetPaged;

public sealed record GetPagedProductsQuery(
    int PageNumber = 1,
    int PageSize = 10
) : IRequest<PagedResult<ProductDetailsDto>>;
