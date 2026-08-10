using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Products.Commands.DeleteProduct;

internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteProductCommandHandler (IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.DeleteByIdAsync(request.id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
