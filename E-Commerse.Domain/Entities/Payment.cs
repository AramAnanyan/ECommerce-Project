namespace ECommerce.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal AmountPaid { get; set; }
        public int PaymentMethodId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Order Order { get; set; } = null!;
        public PaymentMethod PaymentMethod { get; set; } = null!;
        public PaymentStatus Status { get; set; } = null!;
    }
}
