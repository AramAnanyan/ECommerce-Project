using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("aram_reviews", t =>
        {
            t.HasCheckConstraint("aram_reviews_rating_check", "rating >= 1 AND rating <= 5");
        });

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn();

        builder.Property(r => r.CustomerId)
           .HasColumnName("customer_id")
           .IsRequired();

        builder.Property(r => r.ProductId)
           .HasColumnName("product_id")
           .IsRequired();

        builder.Property(r => r.Rating)
           .HasColumnName("rating")
           .IsRequired();

        builder.HasOne(r => r.Customer)
           .WithMany(c => c.Reviews)
           .HasForeignKey(r => r.CustomerId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => r.CustomerId)
           .HasDatabaseName("idx_aram_reviews_customer_id");

        builder.HasIndex(r => r.ProductId)
           .HasDatabaseName("idx_aram_reviews_product_id");
    }
}
