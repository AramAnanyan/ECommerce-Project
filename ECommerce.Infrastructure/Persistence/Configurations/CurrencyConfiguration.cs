using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("aram_currencies");

            builder.HasKey(c=>c.Id);
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
        }
    }
}
