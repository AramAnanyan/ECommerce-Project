using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IReadOnlyList<ProductCategory>> GetCategoriesWithProductsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
