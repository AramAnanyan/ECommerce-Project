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

        public static Review Create(int customerId, int productId, byte rating, string comment)
        {
            return new Review
            {
                CustomerId = customerId,
                ProductId = productId,
                Rating = rating,
                Comment = comment
            };
        }

        public void Update(int customerId, int productId, byte rating, string comment)
        {
            CustomerId = customerId;
            ProductId = productId;
            Rating = rating;
            Comment = comment;
        }
    }
}
