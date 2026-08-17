using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Reviews.Commands.Create;

internal class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReviewCommandHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork    )
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var existingReview = await _reviewRepository.GetByCustomerAndProductAsync(
            request.CustomerId,
            request.ProductId,
            cancellationToken
        );

        if (existingReview != null)
        {
            throw new CustomException("Already reviewed.");
        }

        var review = Review.Create(request.CustomerId, request.ProductId, request.Rating, request.Comment);

        await _reviewRepository.InsertAsync(review, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
