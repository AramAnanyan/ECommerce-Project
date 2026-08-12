using System.ComponentModel;

namespace ECommerce.Domain.Enums;

public enum Currency
{
    [Description("USD")]
    USD = 1,
    [Description("AMD")]
    AMD = 2,
    [Description("EUR")]
    EUR = 3
}
