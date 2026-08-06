namespace ECommerce.Domain.Entities
{
    public class CouponProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CouponId { get; set; }

        public Product Product { get; set; } = null!;
        public Coupon Coupon { get; set; } = null!;

        public static CouponProduct Create(int productId, int couponId)
        {
            return new CouponProduct
            {
                ProductId = productId,
                CouponId = couponId
            };
        }

        public void Update(int productId, int couponId)
        {
            ProductId = productId;
            CouponId = couponId;
        }
    }
}
