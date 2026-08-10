using MediatR;

namespace ECommerce.Application.UseCases.Products.Queries.GetProductById;

public record GetProductByIdQuery(int id) : IRequest<ProductDetailsDto>;