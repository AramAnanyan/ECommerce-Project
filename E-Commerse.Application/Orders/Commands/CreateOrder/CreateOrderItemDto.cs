using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderItemDto(
        int ProductId,
        int Quantity,
        decimal Price
    );
}
