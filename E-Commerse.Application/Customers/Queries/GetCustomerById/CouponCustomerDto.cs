using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Customers.Queries.GetCustomerById
{
    public sealed class CouponCustomerDto
    {
        public string Code { get; set; }
        public int Uses { get; set; }
        public bool IsValid { get; set; }
        public int MaxUses { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
