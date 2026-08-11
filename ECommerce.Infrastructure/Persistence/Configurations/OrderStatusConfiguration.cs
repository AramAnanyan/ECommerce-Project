using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("aram_order_status");

            builder.HasKey(os => os.Id);

            builder.Property(os => os.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(os => os.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(os => os.Name)
                .IsUnique()
                .HasDatabaseName("uq_st_name");
        }
    }
}