
namespace ECommerce.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductCategory Category { get; set; } = null!;
        public Currency Currency { get; set; } = null!;
        public ICollection<ProductCountryAccess> CountryAccesses { get; set; } = new List<ProductCountryAccess>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        
        public ICollection<CouponProduct> CouponProducts { get; set; } = new List<CouponProduct>();
    }
}
