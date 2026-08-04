using ECommerce.Domain.Entities;
namespace ECommerce.Application.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, CancellationToken ct = default);

        Task<PagedResult<T>> GetPagedListAsync(
            int pageNumber,
            int pageSize,
            CancellationToken ct = default);

        Task InsertAsync(T entity, CancellationToken ct = default);

        void Update(T entity);

        void Remove(T entity);
    }
}
