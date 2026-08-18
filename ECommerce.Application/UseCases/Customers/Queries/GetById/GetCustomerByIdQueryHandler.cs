using ECommerce.Application.DTOs.Customer;
using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.UseCases.Customers.Queries.GetById;

internal sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDetailsDto>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<CustomerDetailsDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (customer == null)
        {
            return null; 
        }

        return new CustomerDetailsDto
        {
            Id = customer.Id,
            FullName = customer.FullName,
            EmailAddress = customer.EmailAddress,
            PhoneNumber = customer.PhoneNumber,
            CreatedAt = customer.CreatedAt,
            Addresses = customer.Addresses.Select(x => new CustomerAddressDto
            {
                Country = x.City.Country.Name,
                City = x.City.Name,
                Street = x.Street,
                PostalCode = x.PostalCode
            }).ToList(),
            Reviews = customer.Reviews.Select(x=>new CustomerReviewDto
            {
                ProductId = x.ProductId,
                Rating = x.Rating,
                Comment = x.Comment
            }).ToList(),
            Orders = customer.Orders.Select(x=>new CustomerOrderDto
            {
                OrderId = x.Id,
                CreatedAt=x.CreatedAt,
                Status = x.Status.Name
            }).ToList(),

            CustomerCoupons = customer.CouponCustomers.Select(x=>new CustomerCouponDto
            {
                Code = x.Coupon.Code,
                Uses = x.Uses,
                IsValid = x.IsValid,
                MaxUses = x.Coupon.MaxUses,
                StartDate = x.Coupon.StartDate,
                EndDate = x.Coupon.EndDate
            }).ToList()
        };
    }
}
