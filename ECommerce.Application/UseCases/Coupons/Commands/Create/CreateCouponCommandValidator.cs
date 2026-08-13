using FluentValidation;

namespace ECommerce.Application.UseCases.Coupons.Commands.Create;

public class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
{
    public CreateCouponCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Coupon code is required.");

        RuleFor(x => x.DiscountPercentage)
            .InclusiveBetween(1, 100).WithMessage("Discount percentage must be between 1% and 100%.");

        RuleFor(x => x.MaxUses)
            .GreaterThan(0).WithMessage("Max uses must be at least 1.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End date is required.")
            .GreaterThan(x => x.StartDate).WithMessage("End date must be later than the start date.");

        RuleFor(x => x.CouponProductIds)
            .NotNull().WithMessage("Product Ids cannot be null.");

        RuleFor(x => x.AccessCustomersIds)
            .NotNull().WithMessage("Access customer Ids cannot be null.");
    }
}
