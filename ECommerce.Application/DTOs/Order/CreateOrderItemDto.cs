using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.DTOs.Order
{
    public record CreateOrderItemDto(
        int ProductId,
        int Quantity,
        decimal Price
    );
}
