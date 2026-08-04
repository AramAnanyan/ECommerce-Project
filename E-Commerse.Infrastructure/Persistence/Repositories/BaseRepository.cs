using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await DbSet.FindAsync(new[] { id }, ct);
            
        }

        public virtual async Task<PagedResult<T>> GetPagedListAsync(
            int pageNumber,
            int pageSize,
            CancellationToken ct = default)
        {
            var query = DbSet.AsNoTracking();

            int totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<T>(items, totalCount, pageNumber, pageSize);
        }

        public virtual async Task InsertAsync(T entity, CancellationToken ct = default)
        {
            await DbSet.AddAsync(entity, ct);
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}
