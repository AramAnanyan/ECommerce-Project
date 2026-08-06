namespace ECommerce.Domain.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ProductCategory? ParentCategory { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<ProductCategory> SubCategories { get; set; } = new List<ProductCategory>();

        public static ProductCategory Create(string name, int? parentCategoryId = null)
        {
            return new ProductCategory
            {
                Name = name,
                ParentCategoryId = parentCategoryId
            };
        }

        public void Update(string name, int? parentCategoryId = null)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
        }
    }
}
