using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<Domain.Entities.City>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.City> builder)
        {
            builder.ToTable("aram_cities");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedNever();

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
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.Yerevan,
                    Name = Domain.Enums.City.Yerevan.GetDescription(),
                    CountryId = Domain.Enums.Country.Armenia
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.Gyumri,
                    Name = Domain.Enums.City.Gyumri.GetDescription(),
                    CountryId = Domain.Enums.Country.Armenia
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.NewYork,
                    Name = Domain.Enums.City.NewYork.GetDescription(),
                    CountryId = Domain.Enums.Country.UnitedStates
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.Berlin,
                    Name = Domain.Enums.City.Berlin.GetDescription(),
                    CountryId = Domain.Enums.Country.Germany
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.WestJamesmouth,
                    Name = Domain.Enums.City.WestJamesmouth.GetDescription(),
                    CountryId = Domain.Enums.Country.Armenia
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.Bergerton,
                    Name = Domain.Enums.City.Bergerton.GetDescription(),
                    CountryId = Domain.Enums.Country.UnitedStates
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.SouthJuliemouth,
                    Name = Domain.Enums.City.SouthJuliemouth.GetDescription(),
                    CountryId = Domain.Enums.Country.UnitedStates
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.NorthDonaldhaven,
                    Name = Domain.Enums.City.NorthDonaldhaven.GetDescription(),
                    CountryId = Domain.Enums.Country.Armenia
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.NorthTina,
                    Name = Domain.Enums.City.NorthTina.GetDescription(),
                    CountryId = Domain.Enums.Country.UnitedStates
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.WestKrystal,
                    Name = Domain.Enums.City.WestKrystal.GetDescription(),
                    CountryId = Domain.Enums.Country.Germany
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.Andersonhaven,
                    Name = Domain.Enums.City.Andersonhaven.GetDescription(),
                    CountryId = Domain.Enums.Country.UnitedStates
                },
                new Domain.Entities.City
                {
                    Id = Domain.Enums.City.Ernestshire,
                    Name = Domain.Enums.City.Ernestshire.GetDescription(),
                    CountryId = Domain.Enums.Country.UnitedStates
                }
            );
        }
    }
}