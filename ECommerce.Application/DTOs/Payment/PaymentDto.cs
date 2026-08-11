namespace ECommerce.Application.DTOs.Payment;

public sealed record PaymentDto
{
    public int Id { get; init; }
    public int OrderId { get; init; }
    public decimal AmountPaid { get; init; }
    public string PaymentMethod { get; init; }
    public string Status { get; init; }
    public DateTime CreatedAt { get; init; }
}
