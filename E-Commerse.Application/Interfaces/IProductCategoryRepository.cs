using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<ProductCategory?> GetByIdAsync(int id, CancellationToken ct = default);

        Task<PagedResult<ProductCategory>> GetPagedListAsync(
            int pageNumber,
            int pageSize,
            CancellationToken ct = default);

        Task InsertAsync(ProductCategory productCategory, CancellationToken ct = default);

        Task DeleteByIdAsync(int id, CancellationToken ct);

        Task<IReadOnlyList<ProductCategory>> GetCategoriesWithProductsAsync(CancellationToken ct = default);
    }
}
