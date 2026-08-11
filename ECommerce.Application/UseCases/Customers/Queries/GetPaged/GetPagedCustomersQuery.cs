using ECommerce.Application.DTOs.Customer;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Customers.Queries.GetPaged;

public sealed record GetPagedCustomersQuery(
    int PageNumber = 1,
    int PageSize = 10
) : IRequest<PagedResult<CustomerDetailsDto>>;
