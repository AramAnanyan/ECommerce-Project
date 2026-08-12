namespace ECommerce.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public Enums.Country CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Country Country { get; set; } = null!;
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

        public void Update(string name, Enums.Country countryId)
        {
            Name = name;
            CountryId = countryId;
        }
        public static City Create(Enums.Country countryId, string name)
        {
            return new City {CountryId = countryId, Name = name };
        }
    }
}
