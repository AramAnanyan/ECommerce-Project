namespace ECommerce.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Country Country { get; set; } = null!;
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

        public void Update(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
        }
        public static City Create(int id, int countryId, string name)
        {
            return new City { Id = id, CountryId = countryId, Name = name };
        }
    }
}
