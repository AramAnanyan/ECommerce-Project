using FluentValidation;

namespace ECommerce.Application.UseCases.Products.Queries.GetById;

public class GetProductByIdQueryValidator:AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.Id)
        .GreaterThan(0).WithMessage("Not valid Id.");
    }
}
