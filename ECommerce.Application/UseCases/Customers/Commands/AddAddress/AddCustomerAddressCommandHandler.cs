using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Customers.Commands.AddAddress;

internal sealed class AddCustomerAddressCommandHandler : IRequestHandler<AddCustomerAddressCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AddCustomerAddressCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddCustomerAddressCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId, true, cancellationToken);

        if (customer == null)
        {
            throw new Exception("No customer with given Id");
        }

        var customerAddress = CustomerAddress.Create(request.CityId, request.CustomerId, request.Street, request.PostalCode);
        customer.Addresses.Add(customerAddress);
        await _unitOfWork.SaveChangesAsync();
    }
}
