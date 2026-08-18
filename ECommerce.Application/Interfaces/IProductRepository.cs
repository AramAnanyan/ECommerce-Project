using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id, CancellationToken ct = default);

        Task<PagedResult<Product>> GetPagedListAsync(
            int pageNumber,
            int pageSize,
            CancellationToken ct = default);

        Task InsertAsync(Product product, CancellationToken ct = default);

        Task DeleteByIdAsync(int id, CancellationToken ct);

        Task<IReadOnlyList<Product>> GetProductsByCategoryIdAsync(int categoryId, CancellationToken ct = default);
        Task<Product> GetWithCategoryAndReviewsAsync(int id, CancellationToken ct = default);
    }
}
