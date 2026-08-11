using ECommerce.Domain.Entities;
using ECommerce.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerce.Infrastructure.Persistence.Configurations;

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

        builder.HasData(
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Electronics,
                Name = Domain.Enums.ProductCategory.Electronics.GetDescription(),
                ParentCategoryId = null
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Fashion,
                Name = Domain.Enums.ProductCategory.Fashion.GetDescription(),
                ParentCategoryId = null
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Home,
                Name = Domain.Enums.ProductCategory.Home.GetDescription(),
                ParentCategoryId = null
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Toys,
                Name = Domain.Enums.ProductCategory.Toys.GetDescription(),
                ParentCategoryId = null
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Sport,
                Name = Domain.Enums.ProductCategory.Sport.GetDescription(),
                ParentCategoryId = null
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Laptops,
                Name = Domain.Enums.ProductCategory.Laptops.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Electronics
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Audio,
                Name = Domain.Enums.ProductCategory.Audio.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Electronics
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Accessories,
                Name = Domain.Enums.ProductCategory.Accessories.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Electronics
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Furniture,
                Name = Domain.Enums.ProductCategory.Furniture.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Fashion
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.BoardGames,
                Name = Domain.Enums.ProductCategory.BoardGames.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Fashion
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Footwear,
                Name = Domain.Enums.ProductCategory.Footwear.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Fashion
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.ActionFigures,
                Name = Domain.Enums.ProductCategory.ActionFigures.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Home
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Gym,
                Name = Domain.Enums.ProductCategory.Gym.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Home
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.CampingGear,
                Name = Domain.Enums.ProductCategory.CampingGear.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Home
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Bicycles,
                Name = Domain.Enums.ProductCategory.Bicycles.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Toys
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Cookware,
                Name = Domain.Enums.ProductCategory.Cookware.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Sport
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Appliances,
                Name = Domain.Enums.ProductCategory.Appliances.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Sport
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Crafts,
                Name = Domain.Enums.ProductCategory.Crafts.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Sport
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.Clothing,
                Name = Domain.Enums.ProductCategory.Clothing.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Sport
            },
            new ProductCategory
            {
                Id = (int)Domain.Enums.ProductCategory.AthleticWear,
                Name = Domain.Enums.ProductCategory.AthleticWear.GetDescription(),
                ParentCategoryId = (int)Domain.Enums.ProductCategory.Sport
            }
        );
    }
}
