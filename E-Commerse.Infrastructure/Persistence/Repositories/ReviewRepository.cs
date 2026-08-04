using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IReadOnlyList<Review>> GetReviewsByProductIdAsync(int productId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
