using FluentValidation;

namespace ECommerce.Application.UseCases.Payments.Commands.Delete;

public class DeletePaymentCommandValidator:AbstractValidator<DeletePaymentCommand>
{
    public DeletePaymentCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid payment Id");
    }
}
