namespace ECommerce.Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal MainRate { get; set; }
        public bool IsMain { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
