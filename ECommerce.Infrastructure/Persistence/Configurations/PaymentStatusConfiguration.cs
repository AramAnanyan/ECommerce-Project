using ECommerce.Domain.Entities;
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
    }
}