using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1;
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
        public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEvents = ChangeTracker.Entries()
                .Select(entry => entry.Entity)
                .OfType<Entity>()
                .Where(entity => entity.DomainEvents != null && entity.DomainEvents.Any())
                .SelectMany(entity =>
                {
                    var events = entity.DomainEvents.ToList();
                    entity.ClearDomainEvents();
                    return events;
                })
                .ToList();

            var outboxMessages = domainEvents.Select(domainEvent => new OutboxMessage
            {
                Id = Guid.NewGuid(),
                Type = domainEvent.GetType().AssemblyQualifiedName!,
                Content = JsonSerializer.Serialize(domainEvent, domainEvent.GetType()),
                OccurredOnUtc = DateTime.UtcNow
            }).ToList();

            if (outboxMessages.Any())
            {
                await OutboxMessages.AddRangeAsync(outboxMessages, cancellationToken);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
