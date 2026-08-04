namespace ECommerce.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<City> Cities { get; set; } = new List<City>();
        public ICollection<ProductCountryAccess> ProductCountryAccesses { get; set; } = new List<ProductCountryAccess>();
    }
}
}
