namespace ECommerce.Domain.Entities
{
    public class ProductCategory
    {
        public Enums.ProductCategory Id { get; set; }
        public Enums.ProductCategory? ParentCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ProductCategory? ParentCategory { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<ProductCategory> SubCategories { get; set; } = new List<ProductCategory>();

        public static ProductCategory Create(string name, Enums.ProductCategory? parentCategoryId = null)
        {
            return new ProductCategory
            {
                Name = name,
                ParentCategoryId = parentCategoryId
            };
        }

        public void Update(string name, Enums.ProductCategory? parentCategoryId = null)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
        }
    }
}
