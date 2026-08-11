using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{

    public class CouponProductConfiguration : IEntityTypeConfiguration<CouponProduct>
    {
        public void Configure(EntityTypeBuilder<CouponProduct> builder)
        {
            builder.ToTable("aram_coupons_products");

            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(cp => cp.CouponId)
                .HasColumnName("coupon_id")
                .IsRequired();

            builder.Property(cp => cp.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.HasIndex(cp => new { cp.CouponId, cp.ProductId })
                .IsUnique()
                .HasDatabaseName("uq_coupon_product");

            builder.HasOne(cp => cp.Coupon)
                .WithMany(c => c.CouponProducts)
                .HasForeignKey(cp => cp.CouponId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cp => cp.Product)
                .WithMany(p => p.CouponProducts)
                .HasForeignKey(cp => cp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(cp => cp.ProductId)
                .HasDatabaseName("idx_aram_coupons_products_product_id");
        }
    }
}