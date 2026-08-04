using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("aram_products", t =>
            {
                t.HasCheckConstraint("chk_product_unit_price", "price >= 0");
                t.HasCheckConstraint("chk_product_quantity", "quantity >= 0");
            });

            builder.HasKey(p => p.Id)
                .HasName("aram_product_pkey");
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnName("price")
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(p => p.CategoryId)
                .HasColumnName("category")
                .IsRequired();

            builder.Property(p => p.CurrencyId)
                .HasColumnName("currency")
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("fk_category")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Currency)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CurrencyId)
                .HasConstraintName("aram_product_currency_fkey");

            builder.HasIndex(p => p.CategoryId)
               .HasDatabaseName("idx_aram_products_category");

            builder.HasIndex(p => p.CurrencyId)
               .HasDatabaseName("idx_aram_products_currency");
        }
    }
}