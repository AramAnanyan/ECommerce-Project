using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private AppDbContext _context;
        public CouponRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Coupon> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Coupons.AsNoTracking()
                .Include(x=>x.CouponCustomers)
                    .ThenInclude(x=>x.Customer)
                .Include(x=>x.CouponProducts)
                    .ThenInclude(x=>x.Product)
                        .ThenInclude(x=>x.Category)
                .FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);

        }

        public async Task<Coupon> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _context.Coupons.AsNoTracking()
                .Include(x => x.CouponCustomers)
                    .ThenInclude(x => x.Customer)
                .Include(x => x.CouponProducts)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x=>x.Code == code);

        }

        public async Task<PagedResult<Coupon>> GetPagedListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = _context.Coupons
                .Include(c => c.CouponProducts)
                    .ThenInclude(cp => cp.Product)
                        .ThenInclude(p => p.Category)
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(c => c.StartDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

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
