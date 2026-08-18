using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class OrderRepository :IOrderRepository
    {
        private AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteByIdAsync(int id, CancellationToken ct)
        {
            await _context.Orders.Where(c => c.Id == id).ExecuteDeleteAsync(ct);
        }

        public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x=>x.Currency)
                .Include(x => x.Status)
                .AsNoTracking() // nayel esi inch a
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<PagedResult<Order>> GetPagedListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = _context.Orders
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.Currency)
                .Include(x => x.Status)
                .AsNoTracking() // nayel esi inch a
                .AsNoTracking();

            int totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Order>(items, totalCount, pageNumber, pageSize);
        }

        public async Task<Order?> GetWithDetailsAsync(int id, CancellationToken ct = default)
        {
            return await _context.Orders
            .Include(o => o.OrderItems)
            .Include(o => o.Status)
            .FirstOrDefaultAsync(o => o.Id == id, ct);
        }

        public async Task InsertAsync(Order order, CancellationToken ct = default)
        {
            await _context.Orders.AddAsync(order, ct);
        }
    }
}
