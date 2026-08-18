namespace ECommerce.Application.DTOs.Customer;

public sealed record CustomerReviewDto
{
    public int ProductId { get; init; }
    public int Rating { get; init; }
    public string Comment { get; init; }
}
