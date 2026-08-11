using ECommerce.Application.DTOs.Customer;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;
namespace ECommerce.Application.UseCases.Customers.Queries.GetPaged;

internal sealed class GetPagedCustomersQueryHandler : IRequestHandler<GetPagedCustomersQuery, PagedResult<CustomerDetailsDto>>
{
    private readonly ICustomerRepository _customerRepository;
    public GetPagedCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<PagedResult<CustomerDetailsDto>> Handle(GetPagedCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetPagedListAsync(request.PageNumber,request.PageSize, cancellationToken);
        var pagedResult = new PagedResult<CustomerDetailsDto>(customers.Items.Select(x => new CustomerDetailsDto
        {
            Id = x.Id,
            FullName = x.FullName,
            EmailAddress = x.EmailAddress,
            PhoneNumber = x.PhoneNumber,
            CreatedAt = x.CreatedAt,
            Addresses = x.Addresses.Select(a=>new CustomerAddressDto
            {
                Country = a.City.Country.Name,
                City =a.City.Name,
                Street = a.Street,
                PostalCode = a.PostalCode,
            }).ToList(),
            Reviews = x.Reviews.Select(r => new CustomerReviewDto
            {
                ProductId = r.ProductId,
                Rating = r.Rating,
                Comment = r.Comment
            }).ToList(),
            Orders = x.Orders.Select(o => new CustomerOrderDto
            {
                OrderId = o.Id,
                CreatedAt = o.CreatedAt,
                Status = o.Status.Name
            }).ToList(),

            CustomerCoupons = x.CouponCustomers.Select(c => new CustomerCouponDto
            {
                Code = c.Coupon.Code,
                Uses = c.Uses,
                IsValid = c.IsValid,
                MaxUses = c.Coupon.MaxUses,
                StartDate = c.Coupon.StartDate,
                EndDate = c.Coupon.EndDate
            }).ToList()
        }).ToList(),
            customers.TotalCount, customers.PageNumber, customers.PageSize);
        return pagedResult;
    }
}
