using ECommerce.Application.DTOs.Customer;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Customers.Queries.GetPaged;

public sealed record GetPagedCustomersQuery : IRequest<PagedResult<CustomerDetailsDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
