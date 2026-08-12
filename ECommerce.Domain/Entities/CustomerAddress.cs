namespace ECommerce.Domain.Entities
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public Enums.City CityId { get; set; }
        public int CustomerId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;

        public City City { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public static CustomerAddress Create(Enums.City cityId, int customerId, string street, string postalCode)
        {
            return new CustomerAddress
            {
                CityId = cityId,
                CustomerId = customerId,
                Street = street,
                PostalCode = postalCode
            };
        }

        public void Update(Enums.City cityId, int customerId, string street, string postalCode)
        {
            CityId = cityId;
            CustomerId = customerId;
            Street = street;
            PostalCode = postalCode;
        }
    }
}
