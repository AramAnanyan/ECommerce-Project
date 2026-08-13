using FluentValidation;

namespace ECommerce.Application.UseCases.Products.Commands.Create;

public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.CategoryId)
            .IsInEnum().WithMessage("Invalid product category.");

        RuleFor(x => x.CurrencyId)
            .IsInEnum().WithMessage("Invalid currency.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");
    }
}
