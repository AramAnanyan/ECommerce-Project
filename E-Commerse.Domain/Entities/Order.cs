namespace ECommerce.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StatusId { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public OrderStatus Status { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public CustomerAddress Address { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
