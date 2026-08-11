using ECommerce.Domain.Entities;
using ECommerce.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

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

        builder.HasData(new OrderStatus { Id = (int)Domain.Enums.OrderStatus.Pending, Name = Domain.Enums.OrderStatus.Pending.GetDescription() },
                        new OrderStatus { Id = (int)Domain.Enums.OrderStatus.Completed, Name = Domain.Enums.OrderStatus.Completed.GetDescription() },
                        new OrderStatus { Id = (int)Domain.Enums.OrderStatus.Refunded, Name = Domain.Enums.OrderStatus.Refunded.GetDescription() },
                        new OrderStatus { Id = (int)Domain.Enums.OrderStatus.Cancelled, Name = Domain.Enums.OrderStatus.Cancelled.GetDescription() });
    }
}