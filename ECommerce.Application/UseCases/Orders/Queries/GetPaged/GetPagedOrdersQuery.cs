using ECommerce.Application.DTOs.Order;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Orders.Queries.GetPaged;

public sealed record GetPagedOrdersQuery : IRequest<PagedResult<OrderDetailsDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
