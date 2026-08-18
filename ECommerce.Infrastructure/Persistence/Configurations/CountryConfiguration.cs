using ECommerce.Domain.Entities;
using ECommerce.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("aram_countries");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .HasColumnName("id");

            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasData(
                new Country
                {
                    Id = Domain.Enums.Country.Germany,
                    Name = Domain.Enums.Country.Germany.GetDescription()
                },
                new Country
                {
                    Id = Domain.Enums.Country.Armenia,
                    Name = Domain.Enums.Country.Armenia.GetDescription()
                },
                new Country
                {
                    Id = Domain.Enums.Country.UnitedStates,
                    Name = Domain.Enums.Country.UnitedStates.GetDescription()
                }
            );
        }
    }
}
