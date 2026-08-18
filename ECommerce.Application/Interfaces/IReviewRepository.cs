using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> GetByIdAsync(int id, bool isTracking, CancellationToken ct = default);

        Task<PagedResult<Review>> GetPagedListAsync(
            int pageNumber,
            int pageSize,
            CancellationToken ct = default);

        Task InsertAsync(Review review, CancellationToken ct = default);

        Task DeleteByIdAsync(int id, CancellationToken ct);

        Task<IReadOnlyList<Review>> GetReviewsByProductIdAsync(int productId, CancellationToken ct = default);
        Task<Review> GetByCustomerAndProductAsync(int customerId, int productId, CancellationToken cancellationToken = default);
    }
}
