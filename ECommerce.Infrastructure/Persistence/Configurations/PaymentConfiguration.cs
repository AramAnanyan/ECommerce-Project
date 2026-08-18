using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("aram_payment", t =>
        {
            t.HasCheckConstraint("aram_payment_amount_paid_check", "amount_paid >= 0");
        });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.OrderId)
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(x => x.PaymentMethodId)
            .HasColumnName("payment_method")
            .IsRequired();

        builder.Property(x => x.AmountPaid)
            .HasColumnName("amount_paid")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(x => x.StatusId)
            .HasColumnName("status")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.HasOne(p => p.Order)
            .WithMany(o => o.Payments)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_aram_payments_orders");

        builder.HasOne(x => x.PaymentMethod)
            .WithMany()
            .HasForeignKey(x => x.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_payment_method");

        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_payment_status");

        builder.HasIndex(x => x.OrderId)
            .HasDatabaseName("idx_aram_payment_order_id");

        builder.HasIndex(x => x.PaymentMethodId)
            .HasDatabaseName("idx_aram_payment_payment_method");

        builder.HasIndex(x => x.StatusId)
            .HasDatabaseName("idx_aram_payment_status");
    }
}