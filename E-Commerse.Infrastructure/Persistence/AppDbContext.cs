using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace ECommerce.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Currency> Currencies => Set<Currency>();
        public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
        public DbSet<PaymentStatus> PaymentStatuses => Set<PaymentStatus>();
        public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
        public DbSet<Coupon> Coupons => Set<Coupon>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<CustomerAddress> CustomerAddresses => Set<CustomerAddress>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductCountryAccess> ProductCountryAccesses => Set<ProductCountryAccess>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<CouponProduct> CouponProducts => Set<CouponProduct>();
        public DbSet<CouponCustomer> CouponCustomers => Set<CouponCustomer>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
