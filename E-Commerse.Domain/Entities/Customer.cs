namespace ECommerce.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public ICollection<CustomerAddress> Addresses { get; set; } = new List<CustomerAddress>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<CouponCustomer> CouponCustomers { get; set; } = new List<CouponCustomer>();
    }
}
