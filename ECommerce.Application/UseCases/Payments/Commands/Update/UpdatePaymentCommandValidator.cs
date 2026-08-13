using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Payments.Commands.Update;

public class UpdatePaymentCommandValidator:AbstractValidator<UpdatePaymentCommand>
{
    public UpdatePaymentCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid payment Id.");

        RuleFor(x => x.OrderId)
            .GreaterThan(0).WithMessage("Not valid order Id.");

        RuleFor(x => x.AmountPaid)
            .GreaterThanOrEqualTo(0).WithMessage("Not valid amount paid.");

        RuleFor(x => x.PaymentMethodId)
            .IsInEnum().WithMessage("Invalid payment method.");

        RuleFor(x => x.StatusId)
            .IsInEnum().WithMessage("Invalid payment status.");

        
    }
}
