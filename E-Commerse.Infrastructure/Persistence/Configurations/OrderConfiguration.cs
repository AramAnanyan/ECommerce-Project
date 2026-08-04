using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("aram_orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("now()");

            builder.Property(x => x.StatusId)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.Property(x => x.AddressId)
                .HasColumnName("address")
                .IsRequired();

            builder.HasOne(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("aram_order_status_fkey");

            builder.HasOne(x => x.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_customer");

            builder.HasOne(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("aram_order_address_fkey");

            builder.HasIndex(x => x.StatusId)
                .HasDatabaseName("idx_aram_orders_status");

            builder.HasIndex(x => x.CustomerId)
                .HasDatabaseName("idx_aram_orders_customer_id");

            builder.HasIndex(x => x.AddressId)
                .HasDatabaseName("idx_aram_orders_address");
        }
    }
}