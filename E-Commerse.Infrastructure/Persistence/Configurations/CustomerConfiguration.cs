using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("aram_customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("id");

            builder.Property(c => c.FullName)
                   .HasColumnName("full_name")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.PhoneNumber)
                   .HasColumnName("phone_number")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.EmailAddress)
                   .HasColumnName("email_address")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.HasIndex(c => c.EmailAddress)
                   .IsUnique()
                   .HasDatabaseName("uq_aram_customers_email_address");

            builder.Property(c => c.CreatedAt)
                   .HasColumnName("created_at")
                   .HasColumnType("timestamp with time zone")
                   .HasDefaultValueSql("now()");

        }
    }
}