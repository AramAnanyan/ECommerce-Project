namespace ECommerce.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Country Country { get; set; } = null!;
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
    }
}
