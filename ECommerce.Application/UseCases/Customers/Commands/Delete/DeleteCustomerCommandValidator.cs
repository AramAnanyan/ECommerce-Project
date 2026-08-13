using FluentValidation;

namespace ECommerce.Application.UseCases.Customers.Commands.Delete;

public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid Id.");
    }
}
