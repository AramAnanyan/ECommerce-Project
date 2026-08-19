using ECommerce.Application.DTOs.Payment;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Payments.Queries.GetPaged;

public sealed record GetPagedPaymentsQuery : IRequest<PagedResult<PaymentDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
