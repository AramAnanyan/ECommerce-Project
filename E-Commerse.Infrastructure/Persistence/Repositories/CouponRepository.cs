using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private AppDbContext _context;
        public CouponRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Coupon?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Coupons.FindAsync(new[] { id }, ct);

        }

        public async Task<PagedResult<Coupon>> GetPagedListAsync(
            int pageNumber,
            int pageSize,
            CancellationToken ct = default)
        {
            var query = _context.Coupons.AsNoTracking();

            int totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<Coupon>(items, totalCount, pageNumber, pageSize);
        }

        public async Task InsertAsync(Coupon coupon, CancellationToken ct = default)
        {
            await _context.Coupons.AddAsync(coupon, ct);
        }


        public async Task DeleteByIdAsync(int id,CancellationToken ct)
        {
            await _context.Coupons.Where(c => c.Id == id).ExecuteDeleteAsync(ct);
        }

        public Task<Coupon?> GetValidCouponsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
