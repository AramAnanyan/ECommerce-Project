using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id, CancellationToken ct = default);

        Task<PagedResult<Customer>> GetPagedListAsync(
            int pageNumber,
            int pageSize,
            CancellationToken ct = default);

        Task InsertAsync(Customer customer, CancellationToken ct = default);

        Task DeleteByIdAsync(int id, CancellationToken ct);
        Task<CouponCustomer> GetCustomerCouponAsync(int customerId, string couponCode, CancellationToken cancellationToken = default);
    }
}
