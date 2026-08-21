
using ECommerce.Domain.Common;

namespace ECommerce.Domain.Events;

public class CustomerCreatedEvent:IDomainEvent
{
    public string CustomerEmail { get; set; }
}
