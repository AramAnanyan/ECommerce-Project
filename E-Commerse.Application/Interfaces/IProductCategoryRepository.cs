using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
    {
        Task<IReadOnlyList<ProductCategory>> GetCategoriesWithProductsAsync(CancellationToken ct = default);
    }
}
