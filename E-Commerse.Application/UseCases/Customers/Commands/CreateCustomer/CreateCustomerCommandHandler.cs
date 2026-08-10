using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Customers.Commands.CreateCustomer;

internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _customerRepository.InsertAsync(Customer.Create(request.FullName, request.EmailAddress, request.PhoneNumber));
        await _unitOfWork.SaveChangesAsync();
    }
}
