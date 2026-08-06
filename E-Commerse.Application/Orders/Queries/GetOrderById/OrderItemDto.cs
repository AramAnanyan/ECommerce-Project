using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Orders.Queries.GetOrderById;

public sealed record OrderItemDto
{
    public int ProductId { get; init; }
    public string ProductName { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
    public decimal Discount {  get; init; }
    public decimal TotalPrice { get; init; }
}