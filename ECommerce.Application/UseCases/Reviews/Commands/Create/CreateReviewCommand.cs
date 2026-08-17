using MediatR;

namespace ECommerce.Application.UseCases.Reviews.Commands.Create;

public sealed record CreateReviewCommand:IRequest
{
    public int CustomerId { get; init; }
    public int ProductId { get; init; }
    public int Rating { get; init; }
    public string Comment { get; init; }
}
