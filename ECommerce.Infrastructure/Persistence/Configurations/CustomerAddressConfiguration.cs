using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("aram_customer_addresses");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .HasColumnName("id");

            builder.Property(c => c.Street)
                   .HasColumnName("street")
                   .HasMaxLength(150);
            builder.Property(c => c.PostalCode)
                   .HasColumnName("postal_code")
                   .HasColumnType("text");

            builder.Property(c => c.CustomerId)
                   .HasColumnName("customer_id");

            builder.Property(ca => ca.CityId)
                   .HasColumnName("city")
                   .IsRequired();

            builder.HasOne(ca=>ca.Customer)
                .WithMany(c=>c.Addresses)
                .HasForeignKey(ca=>ca.CustomerId)
                .HasConstraintName("fk_aram_customer_addresses_customer_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ca => ca.City)
                .WithMany(c => c.CustomerAddresses)
                .HasForeignKey(ca => ca.CityId)
                .HasConstraintName("fk_aram_customer_addresses_city")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ca => ca.CustomerId)
                .HasDatabaseName("ix_aram_customer_addresses_customer_id");

            builder.HasIndex(ca => ca.CityId)
                .HasDatabaseName("ix_aram_customer_addresses_city");
        }
    }
}
