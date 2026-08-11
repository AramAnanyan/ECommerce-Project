using ECommerce.Application.DTOs.Customer;
using MediatR;
namespace ECommerce.Application.UseCases.Customers.Queries.GetById;

public record GetCustomerByIdQuery(int id) : IRequest<CustomerDetailsDto>;
