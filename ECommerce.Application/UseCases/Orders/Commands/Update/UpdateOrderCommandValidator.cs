using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Orders.Commands.Update;

public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid order Id.");

        RuleFor(x => x.AddressId)
            .GreaterThan(0).WithMessage("Not valid address Id.");

        RuleFor(x => x.StatusId)
            .IsInEnum().WithMessage("Invalid order status.");

        RuleFor(x => x.Items)
            .NotNull().WithMessage("Order items cannot be null.");

        RuleForEach(x => x.Items).ChildRules(items =>
        {
            items.RuleFor(i => i.ProductId)
                .GreaterThan(0).WithMessage("Not valid product Id.");

            items.RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be at least 1.");
        });
    }
}
