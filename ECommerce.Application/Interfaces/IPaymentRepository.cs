using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByIdAsync(int id, CancellationToken ct = default);

        Task<PagedResult<Payment>> GetPagedListAsync(
            int pageNumber,
            int pageSize,
            CancellationToken ct = default);

        Task InsertAsync(Payment payment, CancellationToken ct = default);

        Task DeleteByIdAsync(int id, CancellationToken ct);

    }
}
