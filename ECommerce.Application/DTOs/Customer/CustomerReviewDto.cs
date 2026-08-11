namespace ECommerce.Application.DTOs.Customer;

public sealed record CustomerReviewDto
{
    public int ProductId { get; init; }
    public byte Rating { get; init; }
    public string Comment { get; init; }
}
