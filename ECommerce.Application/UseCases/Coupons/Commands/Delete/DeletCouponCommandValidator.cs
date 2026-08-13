using FluentValidation;

namespace ECommerce.Application.UseCases.Coupons.Commands.Delete;

public class DeletCouponCommandValidator:AbstractValidator<DeleteCouponCommand>
{
    public DeletCouponCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid Id.");
    }
}
