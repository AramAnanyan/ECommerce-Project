using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Orders.Commands.CreateOrder
{
    public record CreateOrderItemDto(
        int ProductId,
        int Quantity,
        decimal Price
    );
}
