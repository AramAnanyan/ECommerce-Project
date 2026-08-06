using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(int id) : IRequest<CustomerDetailsDto>;
