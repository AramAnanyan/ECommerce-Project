using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Customers.Commands.Update;

public class UpdateCustomerCommandValidator:AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid Id.");

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
