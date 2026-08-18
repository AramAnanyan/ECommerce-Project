using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                .Include(x=>x.Addresses)
                    .ThenInclude(x=>x.City)
                    .ThenInclude(x=>x.Country)
                .Include(x=>x.Orders)
                    .ThenInclude(x=>x.Status)
                .Include(x=>x.CouponCustomers)
                    .ThenInclude(x=>x.Coupon)
                .Include(x=>x.Reviews)
                .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.Id == id,cancellationToken);
        }

        public async Task<PagedResult<Customer>> GetPagedListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = _context.Customers
                .Include(x => x.Addresses)
                    .ThenInclude(x => x.City)
                        .ThenInclude(x => x.Country)
                .Include(x => x.Orders)
                    .ThenInclude(x => x.Status)
                .Include(x => x.CouponCustomers)
                    .ThenInclude(x => x.Coupon)
                .Include(x => x.Reviews)
                .AsNoTracking();

            int totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Customer>(items, totalCount, pageNumber, pageSize);
        }

        public  async Task InsertAsync(Customer customer, CancellationToken ct = default)
        {
            await _context.Customers.AddAsync(customer, ct);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken ct)
        {
            await _context.Customers.Where(c => c.Id == id).ExecuteDeleteAsync(ct);
        }

        public async Task<CouponCustomer> GetCustomerCouponAsync(int customerId, string couponCode, CancellationToken cancellationToken = default)
        {
            return await _context.CouponCustomers
                .Include(cc => cc.Coupon)
                    .ThenInclude(x=>x.CouponProducts)
                .FirstOrDefaultAsync(cc => cc.CustomerId == customerId && cc.Coupon.Code == couponCode, cancellationToken);
        }
    }
}
