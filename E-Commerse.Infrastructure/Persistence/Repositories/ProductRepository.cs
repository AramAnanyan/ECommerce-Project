using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IReadOnlyList<Product>> GetProductsByCategoryIdAsync(int categoryId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetWithCategoryAndReviewsAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
