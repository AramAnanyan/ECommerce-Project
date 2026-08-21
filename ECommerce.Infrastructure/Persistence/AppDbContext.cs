using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Text.Json;

namespace ECommerce.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly IPublisher _publisher;
        public AppDbContext(DbContextOptions<AppDbContext> options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // 1. Grab events BEFORE saving to DB
            var entities = ChangeTracker.Entries<Entity>()
                .Select(entry => entry.Entity)
                .Where(entity => entity.DomainEvents.Any())
                .ToList();

            var domainEvents = entities.SelectMany(e => e.DomainEvents).ToList();

            // 2. Clear events from entities
            foreach (var entity in entities)
            {
                entity.ClearDomainEvents();
            }

            // 3. Save entity changes to PostgreSQL
            var result = await base.SaveChangesAsync(cancellationToken);

            // 4. Publish events to MediatR handlers AFTER saving
            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
