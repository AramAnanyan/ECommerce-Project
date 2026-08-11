using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("aram_product_category");

            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(pc => pc.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(pc => pc.Name)
                .IsUnique()
                .HasDatabaseName("uq_name");

            builder.Property(pc => pc.ParentCategoryId)
                .HasColumnName("parent_category_id");

            builder.HasOne(pc=>pc.ParentCategory)
                .WithMany(p=>p.SubCategories)
                .HasForeignKey(pc => pc.ParentCategoryId)
                .HasConstraintName("fk_parent_category")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
