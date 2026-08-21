using ECommerce.Domain.Common;

namespace ECommerce.Domain.Events;

public record OrderCreatedEvent : IDomainEvent
{
    public string CustomerEmail { get; set; }
}
