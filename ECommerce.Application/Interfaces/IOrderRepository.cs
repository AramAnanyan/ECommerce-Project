using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id, bool isTracking, CancellationToken cancellationToken = default);

        Task<PagedResult<Order>> GetPagedListAsync(
            int pageNumber,
            int pageSize,
            CancellationToken ct = default);

        Task InsertAsync(Order order, CancellationToken ct = default);

        Task DeleteByIdAsync(int id, CancellationToken ct);
        Task<Order> GetWithDetailsAsync(int id, CancellationToken ct = default);
    }
}
