namespace ECommerce.Domain.Entities
{
    public class ProductCountryAccess
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CountryId { get; set; }

        public Product Product { get; set; } = null!;
        public Country Country { get; set; } = null!;

        public static ProductCountryAccess Create(int productId, int countryId)
        {
            return new ProductCountryAccess
            {
                ProductId = productId,
                CountryId = countryId
            };
        }

        public void Update(int productId, int countryId)
        {
            ProductId = productId;
            CountryId = countryId;
        }
    }
}
