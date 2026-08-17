using FluentValidation;

namespace ECommerce.Application.UseCases.Orders.Queries.GetById;

public class GetOrderByIdQueryValidator: AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid Id.");
    }
}
