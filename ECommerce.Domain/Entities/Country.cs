namespace ECommerce.Domain.Entities
{
    public class Country
    {
        public Enums.Country Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<City> Cities { get; set; } = new List<City>();
        public ICollection<ProductCountryAccess> ProductCountryAccesses { get; set; } = new List<ProductCountryAccess>();
        public static Country Create(string name)
        {
            return new Country
            {
                Name = name
            };
        }
        public void Update(string name)
        {
            Name = name;
        }
    }
}

