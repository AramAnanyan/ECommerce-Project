using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{

    public class CouponCustomerConfiguration : IEntityTypeConfiguration<CouponCustomer>
    {
        public void Configure(EntityTypeBuilder<CouponCustomer> builder)
        {
            builder.ToTable("aram_coupons_customers", t =>
            {
                t.HasCheckConstraint("chk_user_coupon_uses", "uses >= 0");
            });

            builder.HasKey(cc => cc.Id);

            builder.Property(cc => cc.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(cc => cc.CouponId)
                .HasColumnName("coupon_id")
                .IsRequired();

            builder.Property(cc => cc.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.Property(cc => cc.Uses)
                .HasColumnName("uses")
                .HasDefaultValue(0);

            builder.Property(cc => cc.IsValid)
                .HasColumnName("is_valid")
                .HasDefaultValue(true);

            builder.HasIndex(cc => new { cc.CouponId, cc.CustomerId })
                .IsUnique()
                .HasDatabaseName("uq_coupon_customer");

            builder.HasOne(cc => cc.Coupon)
                .WithMany(c => c.CouponCustomers)
                .HasForeignKey(cc => cc.CouponId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cc => cc.Customer)
                .WithMany(c => c.CouponCustomers)
                .HasForeignKey(cc => cc.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(cc => cc.CustomerId)
                .HasDatabaseName("idx_aram_coupons_customers_customer_id");
        }
    }
}