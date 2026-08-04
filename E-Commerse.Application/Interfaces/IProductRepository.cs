using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IReadOnlyList<Product>> GetProductsByCategoryIdAsync(int categoryId, CancellationToken ct = default);
        Task<Product?> GetWithCategoryAndReviewsAsync(int id, CancellationToken ct = default);
    }
}
