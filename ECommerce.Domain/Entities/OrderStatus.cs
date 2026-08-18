namespace ECommerce.Domain.Entities
{
    public class OrderStatus
    {
        public Enums.OrderStatus Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
