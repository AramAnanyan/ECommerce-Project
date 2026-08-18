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

        public async Task<Review?> GetByIdAsync(int id, bool isTracking, CancellationToken cancellationToken = default)
        {
            if (isTracking)
            {
                return await _context.Reviews
                    .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            }else
                return await _context.Reviews.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
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

        public async Task<IReadOnlyList<Review>> GetReviewsByProductIdAsync(int productId, CancellationToken cancellationToken = default)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Where(x => x.ProductId == productId)
                .ToListAsync(cancellationToken);
        }
        public async Task<Review> GetByCustomerAndProductAsync(int customerId, int productId, CancellationToken cancellationToken = default)
        {
            return await _context.Reviews
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.CustomerId == customerId && r.ProductId == productId, cancellationToken);
        }
        public async Task InsertAsync(Review review, CancellationToken ct = default)
        {
            await _context.Reviews.AddAsync(review, ct);
        }
    }
}
