using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(int id) : IRequest<CustomerDetailsDto>;
