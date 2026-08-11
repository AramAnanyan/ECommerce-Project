using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{

    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("aram_order_items", t =>
            {
                t.HasCheckConstraint("chk_item_unit_price", "price >= 0");
                t.HasCheckConstraint("chk_item_quantity", "quantity > 0");
                t.HasCheckConstraint("chk_item_discount", "discount >= 0");
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.OrderId)
                .HasColumnName("order_id")
                .IsRequired();

            builder.Property(x => x.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasColumnName("quantity")
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(x => x.Discount)
                .HasColumnName("discount")
                .HasPrecision(10, 2)
                .HasDefaultValue(0.00m)
                .IsRequired();

            builder.HasIndex(x => new { x.OrderId, x.ProductId })
                .IsUnique()
                .HasDatabaseName("uq_order_item");

            builder.HasOne(x => x.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_order");

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_product");

            builder.HasIndex(x => x.ProductId)
                .HasDatabaseName("idx_aram_order_items_product_id");
        }
    }
}