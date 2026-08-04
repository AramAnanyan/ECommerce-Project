using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
