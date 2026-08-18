using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Customers.Commands.Update;

internal sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    ICustomerRepository _customerRepository;
    IUnitOfWork _unitOfWork;
    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id,true, cancellationToken);
        if (customer == null)
        {
            throw new Exception("wrong id");
        }
        customer.Update(request.FullName, request.EmailAddress, request.PhoneNumber);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
