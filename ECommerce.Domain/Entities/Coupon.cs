namespace ECommerce.Domain.Entities;

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

    public static Coupon Create(
            string code,
            decimal discountPercentage,
            int maxUses,
            DateTime startDate,
            DateTime endDate,
            List<int> productIds,
            List<int> customerIds
        )
    {
        var coupon = new Coupon
        {
            Code = code,
            DiscountPercentage = discountPercentage,
            MaxUses = maxUses,
            StartDate = startDate,
            EndDate = endDate
        };


        foreach (var productId in productIds)
        {
            coupon.CouponProducts.Add(new CouponProduct
            {
                ProductId = productId
            });
        }

        foreach (var customerId in customerIds)
        {
            coupon.CouponCustomers.Add(new CouponCustomer
            {
                CustomerId = customerId
            });
        }

        return coupon;
    }

    public void Update(string code, decimal discountPercentage, int maxUses, DateTime startDate, DateTime endDate, List<int> productIds, List<int> customerIds)
    {
        Code = code;
        DiscountPercentage = discountPercentage;
        MaxUses = maxUses;
        StartDate = startDate;
        EndDate = endDate;

        CouponProducts.Clear();

        foreach (var productId in productIds.Distinct())
        {
            CouponProducts.Add(new CouponProduct
            {
                ProductId = productId,
                CouponId = Id
            });
        }

        CouponCustomers.Clear();

        foreach (var customerId in customerIds.Distinct())
        {
            CouponCustomers.Add(new CouponCustomer
            {
                CustomerId = customerId,
                CouponId = Id
            });
        }

    }
}
