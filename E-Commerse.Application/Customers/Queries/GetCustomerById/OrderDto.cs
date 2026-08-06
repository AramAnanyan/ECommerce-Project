using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Customers.Queries.GetCustomerById
{
    public sealed class OrderDto
    {
        public int OrderId { get; init; }
        public DateTime CreatedAt { get; init; }
        public string Status { get; init; }
    }
}
