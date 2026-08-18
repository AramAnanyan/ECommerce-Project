using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Reviews.Commands.Delete;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReviewCommandHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetByIdAsync(request.Id,false, cancellationToken);

        if (review == null)
        {
            throw new CustomException("Review not found.", 404);
        }

        await _reviewRepository.DeleteByIdAsync(review.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}