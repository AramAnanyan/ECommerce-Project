using ECommerce.Domain.Entities;
using ECommerce.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class PaymentStatusConfiguration : IEntityTypeConfiguration<PaymentStatus>
{
    public void Configure(EntityTypeBuilder<PaymentStatus> builder)
    {
        builder.ToTable("aram_payment_status");

        builder.HasKey(ps => ps.Id);

        builder.Property(ps => ps.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn();

        builder.Property(ps => ps.Name)
            .HasColumnName("name")
            .HasMaxLength(15)
            .IsRequired();

        builder.HasIndex(ps => ps.Name)
            .IsUnique()
            .HasDatabaseName("uq_aram_payment_status_name");

        builder.HasData(new PaymentStatus { Id = (int)Domain.Enums.PaymentStatus.Pending, Name = Domain.Enums.PaymentStatus.Pending.GetDescription() },
                        new PaymentStatus { Id = (int)Domain.Enums.PaymentStatus.Paid, Name = Domain.Enums.PaymentStatus.Paid.GetDescription() },
                        new PaymentStatus { Id = (int)Domain.Enums.PaymentStatus.Refunded, Name = Domain.Enums.PaymentStatus.Refunded.GetDescription() },
                        new PaymentStatus { Id = (int)Domain.Enums.PaymentStatus.Cancelled, Name = Domain.Enums.PaymentStatus.Cancelled.GetDescription() });
    }
}