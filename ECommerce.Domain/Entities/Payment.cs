namespace ECommerce.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal AmountPaid { get; set; }
        public Enums.PaymentMethod PaymentMethodId { get; set; }
        public Enums.PaymentStatus StatusId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Order Order { get; set; } = null!;
        public PaymentMethod PaymentMethod { get; set; } = null!;
        public PaymentStatus Status { get; set; } = null!;
        

        public static Payment Create(int orderId, decimal amountPaid, Enums.PaymentMethod paymentMethodId, Enums.PaymentStatus statusId, DateTime? createdAt)
        {
            return new Payment
            {
                OrderId = orderId,
                AmountPaid = amountPaid,
                PaymentMethodId = paymentMethodId,
                StatusId = statusId,
                CreatedAt = createdAt ?? DateTime.UtcNow
            };
        }

        public void Update(int orderId, decimal amountPaid, Enums.PaymentMethod paymentMethodId, Enums.PaymentStatus statusId)
        {
            OrderId = orderId;
            AmountPaid = amountPaid;
            PaymentMethodId = paymentMethodId;
            StatusId = statusId;
        }
    }
}
