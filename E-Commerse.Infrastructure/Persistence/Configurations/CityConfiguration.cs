using ECommerce.Domain.Entities;
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
        }
    }
}