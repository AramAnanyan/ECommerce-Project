using System.ComponentModel;

namespace ECommerce.Domain.Enums;

public enum PaymentMethod
{
    [Description("Credit Card")]
    CreditCard = 1,

    [Description("PayPal")]
    PayPal = 2,

    [Description("Idram")]
    Idram = 3
}