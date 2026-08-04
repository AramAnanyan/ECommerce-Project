namespace ECommerce.Domain.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public decimal DiscountPercentage { get; set; }
        public int MaxUses { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<CouponCustomer> CouponCustomers { get; set; } = new List<CouponCustomer>();
        public ICollection<CouponProduct> CouponProducts { get; set; } = new List<CouponProduct>();

    }
}
