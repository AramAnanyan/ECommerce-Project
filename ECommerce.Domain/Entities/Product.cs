
namespace ECommerce.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public Enums.ProductCategory CategoryId { get; set; }
        public Enums.Currency CurrencyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public ProductCategory Category { get; set; } = null!;
        public Currency Currency { get; set; } = null!;
        public ICollection<ProductCountryAccess> CountryAccesses { get; set; } = new List<ProductCountryAccess>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<CouponProduct> CouponProducts { get; set; } = new List<CouponProduct>();

        public static Product Create(Enums.ProductCategory categoryId, Enums.Currency currencyId, string name, decimal price, int quantity)
        {
            return new Product
            {
                CategoryId = categoryId,
                CurrencyId = currencyId,
                Name = name,
                Price = price,
                Quantity = quantity
            };
        }

        public void Update(Enums.ProductCategory categoryId, Enums.Currency currencyId, string name, decimal price, int quantity)
        {
            CategoryId = categoryId;
            CurrencyId = currencyId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
