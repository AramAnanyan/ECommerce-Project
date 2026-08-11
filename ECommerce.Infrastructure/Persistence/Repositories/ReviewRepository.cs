using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id, CancellationToken ct)
        {
            await _context.Reviews.Where(c => c.Id == id).ExecuteDeleteAsync(ct);
        }

        public async Task<Review?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Reviews.FindAsync(new[] { id }, ct);
        }

        public async Task<PagedResult<Review>> GetPagedListAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        {
            var query = _context.Reviews.AsNoTracking();

            int totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<Review>(items, totalCount, pageNumber, pageSize);
        }

        public Task<IReadOnlyList<Review>> GetReviewsByProductIdAsync(int productId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Review review, CancellationToken ct = default)
        {
            await _context.Reviews.AddAsync(review, ct);
        }
    }
}
