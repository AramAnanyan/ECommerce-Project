using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id, CancellationToken ct)
        {
            await _context.Payments.Where(c => c.Id == id).ExecuteDeleteAsync(ct);
        }

        public async Task<Payment?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Payments.AsNoTracking()
                .Include(p => p.PaymentMethod)
                .Include(p=>p.Status)
                .FirstOrDefaultAsync(p=>p.Id == id,cancellationToken);
        }

        public async Task<PagedResult<Payment>> GetPagedListAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        {
            var query = _context.Payments.AsNoTracking();

            int totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<Payment>(items, totalCount, pageNumber, pageSize);
        }

        public async Task InsertAsync(Payment payment, CancellationToken ct = default)
        {
            await _context.Payments.AddAsync(payment, ct);
        }
    }
}
