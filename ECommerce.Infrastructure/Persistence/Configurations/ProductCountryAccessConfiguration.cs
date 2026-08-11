using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class ProductCountryAccessConfiguration : IEntityTypeConfiguration<ProductCountryAccess>
{
    public void Configure(EntityTypeBuilder<ProductCountryAccess> builder)
    {
        builder.ToTable("aram_product_country_access");

        builder.HasKey(pca => pca.Id);
        builder.Property(pca=>pca.Id)
            .HasColumnName("id")
            .UseIdentityByDefaultColumn();

        builder.Property(pca => pca.ProductId)
            .HasColumnName("product")
            .IsRequired();

        builder.Property(pca => pca.CountryId)
            .HasColumnName("country")
            .IsRequired();

        builder.HasIndex(pca => new { pca.ProductId, pca.CountryId })
           .IsUnique()
           .HasDatabaseName("uq_product_country");

        builder.HasOne(pca => pca.Product)
            .WithMany(p=>p.CountryAccesses)
            .HasForeignKey(p=>p.ProductId)
            .HasConstraintName("fk_product")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pca => pca.Country)
            .WithMany(c => c.ProductCountryAccesses)
            .HasForeignKey(pca => pca.CountryId)
            .HasConstraintName("fk_country")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(pca => pca.CountryId)
           .HasDatabaseName("idx_aram_product_country_access_country");
    }
}
