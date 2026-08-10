using MediatR;

namespace ECommerce.Application.UseCases.Customers.Commands.DeleteCustomer;

public sealed record DeleteCustomerCommand(int id):IRequest;
