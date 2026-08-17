using ECommerce.Application.DTOs.Customer;
using MediatR;
namespace ECommerce.Application.UseCases.Customers.Queries.GetById;

public record GetCustomerByIdQuery : IRequest<CustomerDetailsDto>
{
    public int Id { get; init; }
}
