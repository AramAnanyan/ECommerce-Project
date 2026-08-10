using ECommerce.Application.Customers.Queries.GetCustomerById;
using ECommerce.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.UseCases.Customers.Queries.GetCustomerById;

internal sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDetailsDto>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<CustomerDetailsDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.id, cancellationToken);

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
            Addresses = customer.Addresses.Select(x => new AddressDto
            {
                Country = x.City.Country.Name,
                City = x.City.Name,
                Street = x.Street,
                PostalCode = x.PostalCode
            }).ToList(),
            Reviews = customer.Reviews.Select(x=>new ReviewDto
            {
                ProductId = x.ProductId,
                Rating = x.Rating,
                Comment = x.Comment
            }).ToList(),
            Orders = customer.Orders.Select(x=>new OrderDto
            {
                OrderId = x.Id,
                CreatedAt=x.CreatedAt,
                Status = x.Status.Name
            }).ToList(),

            CustomerCoupons = customer.CouponCustomers.Select(x=>new CouponCustomerDto
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
