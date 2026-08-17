using ECommerce.Application.DTOs.Product;
using MediatR;

namespace ECommerce.Application.UseCases.Products.Queries.GetById;

public record GetProductByIdQuery : IRequest<ProductDetailsDto>
{
    public int Id { get; init; }
}