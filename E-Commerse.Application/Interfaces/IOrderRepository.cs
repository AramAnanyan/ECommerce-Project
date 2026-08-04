using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order?> GetWithDetailsAsync(int id, CancellationToken ct = default);
    }
}
