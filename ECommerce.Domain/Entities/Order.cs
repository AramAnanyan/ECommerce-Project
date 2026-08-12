namespace ECommerce.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Enums.OrderStatus StatusId { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }

        public OrderStatus Status { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public CustomerAddress Address { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = [];
        public ICollection<Payment> Payments { get; set; } = [];

        public static Order Create(
            Enums.OrderStatus statusId,
            int customerId,
            int addressId,
            List<OrderItem> items)
        {
            return new Order
            {
                StatusId = statusId,
                CustomerId = customerId,
                AddressId = addressId,
                CreatedAt = DateTime.UtcNow,
                OrderItems = items
            };
        }

        public void Update(Enums.OrderStatus statusId, int addressId, List<OrderItem> items)
        {
            StatusId = statusId;
            AddressId = addressId;
            items = items ?? new List<OrderItem>();
        }
    }
}
