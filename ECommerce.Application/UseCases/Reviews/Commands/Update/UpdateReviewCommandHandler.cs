using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Reviews.Commands.Update;

public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateReviewCommandHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetByIdAsync(request.Id, cancellationToken);

        if (review == null)
        {
            throw new CustomException("Review not found.", 404);
        }
        review.Update(review.Rating, review.Comment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
