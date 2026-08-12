using ECommerce.Domain.Entities;
using ECommerce.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("aram_cities");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id");

            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.CountryId)
                   .HasColumnName("country")
                   .IsRequired();

            builder.HasOne(c => c.Country)
                   .WithMany(co => co.Cities)
                   .HasForeignKey(c => c.CountryId)
                   .HasConstraintName("fk_aram_cities_country")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(c => c.CountryId)
               .HasDatabaseName("ix_aram_cities_country");

            builder.HasData(
                new City
                {
                    Id = (int)Domain.Enums.City.Yerevan,
                    Name = Domain.Enums.City.Yerevan.GetDescription(),
                    CountryId = 1
                },
                new City
                {
                    Id = (int)Domain.Enums.City.Gyumri,
                    Name = Domain.Enums.City.Gyumri.GetDescription(),
                    CountryId = 1
                },
                new City
                {
                    Id = (int)Domain.Enums.City.NewYork,
                    Name = Domain.Enums.City.NewYork.GetDescription(),
                    CountryId = 2
                },
                new City
                {
                    Id = (int)Domain.Enums.City.Berlin,
                    Name = Domain.Enums.City.Berlin.GetDescription(),
                    CountryId = 3
                },
                new City
                {
                    Id = (int)Domain.Enums.City.WestJamesmouth,
                    Name = Domain.Enums.City.WestJamesmouth.GetDescription(),
                    CountryId = 1
                },
                new City
                {
                    Id = (int)Domain.Enums.City.Bergerton,
                    Name = Domain.Enums.City.Bergerton.GetDescription(),
                    CountryId = 2
                },
                new City
                {
                    Id = (int)Domain.Enums.City.SouthJuliemouth,
                    Name = Domain.Enums.City.SouthJuliemouth.GetDescription(),
                    CountryId = 2
                },
                new City
                {
                    Id = (int)Domain.Enums.City.NorthDonaldhaven,
                    Name = Domain.Enums.City.NorthDonaldhaven.GetDescription(),
                    CountryId = 1
                },
                new City
                {
                    Id = (int)Domain.Enums.City.NorthTina,
                    Name = Domain.Enums.City.NorthTina.GetDescription(),
                    CountryId = 2
                },
                new City
                {
                    Id = (int)Domain.Enums.City.WestKrystal,
                    Name = Domain.Enums.City.WestKrystal.GetDescription(),
                    CountryId = 3
                },
                new City
                {
                    Id = (int)Domain.Enums.City.Andersonhaven,
                    Name = Domain.Enums.City.Andersonhaven.GetDescription(),
                    CountryId = 2
                },
                new City
                {
                    Id = (int)Domain.Enums.City.Ernestshire,
                    Name = Domain.Enums.City.Ernestshire.GetDescription(),
                    CountryId = 2
                }
            );
        }
    }
}