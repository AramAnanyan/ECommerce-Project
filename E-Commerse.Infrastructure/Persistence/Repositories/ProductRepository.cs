using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id, CancellationToken ct)
        {
            await _context.Products.Where(c => c.Id == id).ExecuteDeleteAsync(ct);
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(x=>x.Category)
                    .ThenInclude(x=>x.ParentCategory)
                .Include(x=>x.Currency)
                .Include(x=>x.CountryAccesses)
                    .ThenInclude(x=>x.Country)
                .Include(x=>x.Reviews)
                    .ThenInclude(x=>x.Customer)
                .FirstOrDefaultAsync(c => c.Id == id,cancellationToken);
        }

        public async Task<PagedResult<Product>> GetPagedListAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        {
            var query = _context.Products.AsNoTracking();

            int totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<Product>(items, totalCount, pageNumber, pageSize);
        }

        public Task<IReadOnlyList<Product>> GetProductsByCategoryIdAsync(int categoryId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetWithCategoryAndReviewsAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Product product, CancellationToken ct = default)
        {
            await _context.Products.AddAsync(product, ct);
        }
    }
}
