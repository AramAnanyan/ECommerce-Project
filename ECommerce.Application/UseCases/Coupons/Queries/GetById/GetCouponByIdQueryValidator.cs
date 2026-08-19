using FluentValidation;

namespace ECommerce.Application.UseCases.Coupons.Queries.GetById;

public class GetCouponByIdQueryValidator:AbstractValidator<GetCouponByIdQuery>
{
    public GetCouponByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid Id");
    }
}
