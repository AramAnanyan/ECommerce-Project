using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class CouponRepository : BaseRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Coupon?> GetValidCouponsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
