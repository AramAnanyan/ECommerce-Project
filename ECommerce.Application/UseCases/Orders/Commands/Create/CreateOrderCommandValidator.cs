using FluentValidation;

namespace ECommerce.Application.UseCases.Orders.Commands.Create;

public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Not valid customer Id.");

        RuleFor(x => x.AddressId)
            .GreaterThan(0).WithMessage("Not valid address Id.");

        RuleFor(x => x.StatusId)
            .IsInEnum().WithMessage("Invalid order status.");

        RuleFor(x => x.Items)
            .NotNull().WithMessage("Order items cannot be null.")
            .NotEmpty().WithMessage("Order must contain at least one item.");

        RuleForEach(x => x.Items).ChildRules(items =>
        {
            items.RuleFor(i => i.ProductId)
                .GreaterThan(0).WithMessage("Not valid product Id.");

            items.RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be at least 1");
        });
    }
}
