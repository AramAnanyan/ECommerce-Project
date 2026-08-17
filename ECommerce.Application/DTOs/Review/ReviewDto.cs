namespace ECommerce.Application.DTOs.Review;

public sealed record ReviewDto
{
    public int Id { get; set; }
    public int CustomerId {  get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}
