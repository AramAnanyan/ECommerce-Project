namespace ECommerce.Domain.Entities
{
    public class ProductCountryAccess
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Enums.Country CountryId { get; set; }

        public Product Product { get; set; } = null!;
        public Country Country { get; set; } = null!;

        public static ProductCountryAccess Create(int productId, Enums.Country countryId)
        {
            return new ProductCountryAccess
            {
                ProductId = productId,
                CountryId = countryId
            };
        }

        public void Update(int productId, Enums.Country countryId)
        {
            ProductId = productId;
            CountryId = countryId;
        }
    }
}
