

using FluentValidation;

namespace ECommerce.Application.UseCases.Orders.Commands.Delete;

public class DeleteOrderCommandValidator:AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid Id.");
    }
}
