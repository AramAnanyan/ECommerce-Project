using MediatR;

namespace ECommerce.Application.UseCases.Customers.Commands.Delete;

public sealed record DeleteCustomerCommand(int Id):IRequest;
