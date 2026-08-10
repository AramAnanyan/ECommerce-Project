using MediatR;
namespace ECommerce.Application.UseCases.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(int id) : IRequest;
