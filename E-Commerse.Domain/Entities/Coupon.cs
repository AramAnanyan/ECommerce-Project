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

        public static Coupon Create(string code, decimal discountPercentage, int maxUses, DateTime startDate, DateTime endDate)
        {
            return new Coupon
            {
                Code = code,
                DiscountPercentage = discountPercentage,
                MaxUses = maxUses,
                StartDate = startDate,
                EndDate = endDate
            };
        }

        public void Update(string code, decimal discountPercentage, int maxUses, DateTime startDate, DateTime endDate)
        {
            Code = code;
            DiscountPercentage = discountPercentage;
            MaxUses = maxUses;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
