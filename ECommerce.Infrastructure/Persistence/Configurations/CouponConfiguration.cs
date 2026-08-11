using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{

    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("aram_coupons", t =>
            {
                t.HasCheckConstraint("chk_coupon_discount",
                    "discount_percentage >= 0 AND discount_percentage <= 100");
                t.HasCheckConstraint("chk_coupon_max_uses", "max_uses >= 0");
                t.HasCheckConstraint("chk_coupon_dates", "start_date <= end_date");
            });
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(c => c.Code)
                .HasColumnName("code")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(c => c.Code)
                .IsUnique()
                .HasDatabaseName("uq_coupon_code");

            builder.Property(c => c.DiscountPercentage)
                .HasColumnName("discount_percentage")
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(c => c.MaxUses)
                .HasColumnName("max_uses")
                .IsRequired();

            builder.Property(c => c.StartDate)
                .HasColumnName("start_date")
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("now()")
                .IsRequired();

            builder.Property(c => c.EndDate)
                .HasColumnName("end_date")
                .HasColumnType("timestamp with time zone")
                .IsRequired();
        }
    }
}