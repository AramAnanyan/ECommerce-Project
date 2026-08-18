using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Products.Commands.Update;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id,true, cancellationToken);
        product.Update(
                request.CategoryId,
                request.CurrencyId,
                request.Name,
                request.Price,
                request.Quantity
            );

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
