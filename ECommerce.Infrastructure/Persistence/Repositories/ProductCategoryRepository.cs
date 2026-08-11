using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id, CancellationToken ct)
        {
            await _context.ProductCategories.Where(c => c.Id == id).ExecuteDeleteAsync(ct);
        }

        public async Task<ProductCategory?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.ProductCategories.FindAsync(new[] { id }, ct);
        }

        public Task<IReadOnlyList<ProductCategory>> GetCategoriesWithProductsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductCategory>> GetPagedListAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        {
            var query = _context.ProductCategories.AsNoTracking();

            int totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<ProductCategory>(items, totalCount, pageNumber, pageSize);
        }

        public async Task InsertAsync(ProductCategory productCategory, CancellationToken ct = default)
        {
            await _context.ProductCategories.AddAsync(productCategory, ct);
        }
    }
}
