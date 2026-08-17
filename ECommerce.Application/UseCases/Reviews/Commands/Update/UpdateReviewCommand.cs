using MediatR;


namespace ECommerce.Application.UseCases.Reviews.Commands.Update;

public sealed record UpdateReviewCommand:IRequest
{
    public int Id { get; init; }
    public int Rating { get; init; }
    public string Comment { get; init; }
}
