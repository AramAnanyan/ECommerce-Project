using FluentValidation;

namespace ECommerce.Application.UseCases.Customers.Queries.GetById;

public class GetCustomerByIdQueryValidator:AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid Id.");
    }
}
