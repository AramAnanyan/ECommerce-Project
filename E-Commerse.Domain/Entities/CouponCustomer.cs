namespace ECommerce.Domain.Entities
{
    public class CouponCustomer
    {
        public int Id { get; set; }
        public int CouponId { get; set; }
        public int CustomerId { get; set; }
        public int Uses { get; set; }
        public bool IsValid { get; set; }
        public Coupon Coupon { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
    }
}
