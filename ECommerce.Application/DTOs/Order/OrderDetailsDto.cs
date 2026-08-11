using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.DTOs.Order;

public sealed record OrderDetailsDto
{
    public int Id { get; init; }
    public int CustomerId { get; init; }
    public string StatusName { get; init; }
    public DateTime CreatedAt { get; init; }
    public decimal TotalAmount { get; init; }
    public List<OrderItemDto> Items { get; init; }
}
