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

        public static CouponCustomer Create(int couponId, int customerId, int uses, bool isValid)
        {
            return new CouponCustomer
            {
                CouponId = couponId,
                CustomerId = customerId,
                Uses = uses,
                IsValid = isValid
            };
        }

        public void Update(int couponId, int customerId, int uses, bool isValid)
        {
            CouponId = couponId;
            CustomerId = customerId;
            Uses = uses;
            IsValid = isValid;
        }
    }
}
