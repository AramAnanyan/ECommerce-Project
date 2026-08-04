namespace ECommerce.Domain.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ProductCategory? ParentCategory { get; set; }
        public ICollection<Product> Products = new List<Product>();
        public ICollection<ProductCategory> SubCategories = new List<ProductCategory>();
    }
}
