namespace ECommerce.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public byte Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public Customer Customer { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
