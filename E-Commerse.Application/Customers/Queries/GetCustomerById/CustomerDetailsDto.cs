using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Customers.Queries.GetCustomerById
{
    public sealed class CustomerDetailsDto
    {
        public int Id { get; init; }
        public string FullName { get; init; }
        public string EmailAddress { get; init; }
        public string PhoneNumber { get; init; }
        public DateTime CreatedAt { get; init; }
        public List<AddressDto> Addresses { get; set; }
        public List<ReviewDto> Reviews { get; set; }
        public List<OrderDto> Orders { get; set; }
        public List<CouponCustomerDto> CustomerCoupons { get; set; }
    }
}
