namespace ECommerce.Domain.Entities
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int CustomerId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string PostalCode {  get; set; } = string.Empty;
        public City City { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
