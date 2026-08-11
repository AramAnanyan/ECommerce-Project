using ECommerce.Application.DTOs.Order;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Orders.Queries.GetPaged;

public sealed record GetPagedOrdersQuery(
    int PageNumber = 1,
    int PageSize = 10
) : IRequest<PagedResult<OrderDetailsDto>>;
