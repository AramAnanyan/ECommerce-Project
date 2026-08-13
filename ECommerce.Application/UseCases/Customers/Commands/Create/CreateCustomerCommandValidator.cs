
using FluentValidation;

namespace ECommerce.Application.UseCases.Customers.Commands.Create;

public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(50).WithMessage("Full name cannot be more than 50 characters.");

        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.");
    }
}
