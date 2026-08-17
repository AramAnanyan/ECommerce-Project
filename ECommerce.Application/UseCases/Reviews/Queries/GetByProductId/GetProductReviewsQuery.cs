using ECommerce.Application.DTOs.Review;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Reviews.Queries.GetByProductId
{
    public class GetProductReviewsQuery:IRequest<List<ReviewDto>>
    {
        public int ProductId { get; init; }
    }
}
