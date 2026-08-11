using System.ComponentModel;

namespace ECommerce.Domain.Enums;

public enum OrderStatus
{
    [Description("Pending")]
    Pending = 1,

    [Description("Completed")]
    Completed = 2,

    [Description("Cancelled")]
    Cancelled = 4,

    [Description("Refunded")]
    Refunded = 5
}
