namespace ECommerce.Domain.Entities
{
    public class ProductCountryAccess
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CountryId { get; set; }
        public Product Product { get; set; } = null!;
        public Country Country { get; set; } = null!;
    }
}
