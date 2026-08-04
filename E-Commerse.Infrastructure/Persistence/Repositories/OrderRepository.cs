using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Order?> GetWithDetailsAsync(int id, CancellationToken ct = default)
        {
            return await DbSet
            .Include(o => o.OrderItems)
            .Include(o => o.Status)
            .FirstOrDefaultAsync(o => o.Id == id, ct);
        }
    }
}
