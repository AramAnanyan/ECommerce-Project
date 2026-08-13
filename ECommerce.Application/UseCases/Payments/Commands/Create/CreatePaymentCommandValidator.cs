using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Payments.Commands.Create;

public class CreatePaymentCommandValidator:AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0).WithMessage("Not valid order Id.");

        RuleFor(x => x.AmountPaid)
            .GreaterThanOrEqualTo(0).WithMessage("Not valid amount paid.");

        RuleFor(x => x.PaymentMethodId)
            .IsInEnum().WithMessage("Invalid payment method.");

        RuleFor(x => x.StatusId)
            .IsInEnum().WithMessage("Invalid payment status.");

        RuleFor(x => x.CreatedAt)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Created date cannot be in the future.")
            .When(x => x.CreatedAt.HasValue);
    }
}
