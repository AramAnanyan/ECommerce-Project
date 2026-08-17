using FluentValidation;

namespace ECommerce.Application.UseCases.Reviews.Queries.GetByProductId;

public class GetByProductReviewsQueryValidator:AbstractValidator<GetProductReviewsQuery>
{
    public GetByProductReviewsQueryValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("Not valid product Id.");
    }
}
