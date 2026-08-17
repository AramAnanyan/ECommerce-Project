using ECommerce.Application.DTOs.Review;
using ECommerce.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Reviews.Queries.GetByProductId;

public class GetProductReviewsQueryHandler : IRequestHandler<GetProductReviewsQuery, List<ReviewDto>>
{
    private readonly IReviewRepository _reviewRepository;

    public GetProductReviewsQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<List<ReviewDto>> Handle(GetProductReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepository.GetReviewsByProductIdAsync(request.ProductId, cancellationToken);

        return reviews.Select(r => new ReviewDto {
            Id = r.Id,
            CustomerId = r.CustomerId,
            Rating = r.Rating,
            Comment = r.Comment
        }).ToList();
    }
}
