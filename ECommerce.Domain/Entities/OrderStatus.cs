namespace ECommerce.Domain.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public static OrderStatus Create(string name)
        {
            return new OrderStatus
            {
                Name = name
            };
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
