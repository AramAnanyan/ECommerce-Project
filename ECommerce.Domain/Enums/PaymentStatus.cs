using System.ComponentModel;

namespace ECommerce.Domain.Enums;

public enum PaymentStatus
{
    [Description("Pending")]
    Pending = 1,

    [Description("Paid")]
    Paid = 2,

    [Description("Refunded")]
    Refunded = 3,

    [Description("Cancelled")]
    Cancelled = 4
}
