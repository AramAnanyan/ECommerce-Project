using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface ICouponRepository
    {
        Task<Coupon?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Coupon> GetByCodeAsync(string code, CancellationToken cancellationToken = default);

        Task<PagedResult<Coupon>> GetPagedListAsync(
            int pageNumber,
            int pageSize,
            CancellationToken ct = default);

        Task InsertAsync(Coupon coupon, CancellationToken ct = default);

        Task DeleteByIdAsync(int id, CancellationToken ct);

        Task<Coupon?> GetValidCouponsAsync(CancellationToken ct = default);
    }
}
