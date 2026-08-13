
using FluentValidation;

namespace ECommerce.Application.UseCases.Products.Commands.Delete;

public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Not valid product Id");
    }
}
