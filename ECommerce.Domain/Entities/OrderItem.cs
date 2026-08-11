namespace ECommerce.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;

        public static OrderItem Create(int orderId, int productId, int quantity, decimal price, decimal discount)
        {
            return new OrderItem
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity,
                Price = price,
                Discount = discount
            };
        }

        public void Update(int orderId, int productId, int quantity, decimal price, decimal discount)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            Discount = discount;
        }
    }
}
