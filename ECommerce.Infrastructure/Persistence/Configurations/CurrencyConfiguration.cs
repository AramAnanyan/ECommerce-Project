using ECommerce.Domain.Entities;
using ECommerce.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("aram_currencies");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.IsMain)
                .HasColumnName("is_main")
                .HasDefaultValue(false);

            builder.Property(c => c.MainRate)
                .HasColumnName("main_rate")
                .HasPrecision(10, 2);

            builder.HasData(
                new Currency
                {
                    Id = (int)Domain.Enums.Currency.AMD,
                    Name = Domain.Enums.Currency.AMD.GetDescription(),
                    MainRate = 388.50M,
                    IsMain = false
                },
                new Currency
                {
                    Id = (int)Domain.Enums.Currency.USD,
                    Name = Domain.Enums.Currency.USD.GetDescription(),
                    MainRate = 1M,
                    IsMain = true
                },
                new Currency
                {
                    Id = (int)Domain.Enums.Currency.EUR,
                    Name = Domain.Enums.Currency.EUR.GetDescription(),
                    MainRate = 0.92M,
                    IsMain = false
                }
            );
        }
    }
}
