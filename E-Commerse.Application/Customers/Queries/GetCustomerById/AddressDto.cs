using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Customers.Queries.GetCustomerById
{
    public sealed class AddressDto
    {
        public string Country {  get; init; }
        public string City { get; init; }
        public string Street { get; init; } 
        public string PostalCode { get; init; } 
    }
}
