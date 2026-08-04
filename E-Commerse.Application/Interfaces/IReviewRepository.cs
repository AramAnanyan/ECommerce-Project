using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<IReadOnlyList<Review>> GetReviewsByProductIdAsync(int productId, CancellationToken ct = default);
    }
}
