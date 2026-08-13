using MediatR;
namespace ECommerce.Application.UseCases.Products.Commands.Delete;

public sealed record DeleteProductCommand(int Id) : IRequest;
