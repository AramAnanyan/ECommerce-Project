using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Customers.Commands.Delete;

internal sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await _customerRepository.DeleteByIdAsync(request.id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
