using ECommerce.Domain.Entities;
using ECommerce.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.ToTable("aram_payment_method");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(15)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique()
            .HasDatabaseName("uq_aram_payment_method");

        builder.HasData(new PaymentMethod { Id = Domain.Enums.PaymentMethod.PayPal, Name = Domain.Enums.PaymentMethod.PayPal.GetDescription() },
                        new PaymentMethod { Id = Domain.Enums.PaymentMethod.Idram, Name = Domain.Enums.PaymentMethod.Idram.GetDescription() },
                        new PaymentMethod { Id = Domain.Enums.PaymentMethod.CreditCard, Name = Domain.Enums.PaymentMethod.CreditCard.GetDescription() });
    }
}
