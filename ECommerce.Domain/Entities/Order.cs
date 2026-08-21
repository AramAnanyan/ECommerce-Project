using ECommerce.Domain.Common;
using ECommerce.Domain.Events;

namespace ECommerce.Domain.Entities;

public class Order:Entity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Enums.OrderStatus StatusId { get; set; }
    public int CustomerId { get; set; }
    public int AddressId { get; set; }

    public OrderStatus Status { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public CustomerAddress Address { get; set; } = null!;
    public ICollection<OrderItem> OrderItems { get; set; } = [];
    public ICollection<Payment> Payments { get; set; } = [];

    public static Order Create(
        string email,
        Enums.OrderStatus statusId,
        int customerId,
        int addressId,
        List<OrderItem> items)
    {
        var order = new Order
        {
            StatusId = statusId,
            CustomerId = customerId,
            AddressId = addressId,
            CreatedAt = DateTime.UtcNow,
            OrderItems = items
        };
        order.RaiseDomainEvent(new OrderCreatedEvent { CustomerEmail = email });
        return order;
    }

    public void Update(Enums.OrderStatus statusId ,int addressId, List<OrderItem> items)
    {
        StatusId = statusId;
        AddressId = addressId;

        var productIds = items.Select(i => i.ProductId).ToHashSet();
        var itemsToRemove = OrderItems.Where(i => !productIds.Contains(i.ProductId)).ToList();

        foreach (var item in itemsToRemove)
            OrderItems.Remove(item);

        foreach (var newItem in items)
        {
            var existingItem = OrderItems.FirstOrDefault(i => i.ProductId == newItem.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity = newItem.Quantity;
                existingItem.Price = newItem.Price;
                existingItem.Discount = newItem.Discount;
            }
            else
            {
                OrderItems.Add(newItem);
            }
        }
    }
}
