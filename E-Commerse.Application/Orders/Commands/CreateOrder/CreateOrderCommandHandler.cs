using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Orders.Commands.CreateOrder;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        CouponCustomer customerCoupon = null;
        if (!string.IsNullOrWhiteSpace(request.CouponCode))
        {
            customerCoupon = await _customerRepository.GetCustomerCouponAsync(request.CustomerId, request.CouponCode, cancellationToken);
            if (customerCoupon == null || !customerCoupon.IsValid)
            {
                throw new Exception("Coupon is not valid");
            }
        }

        var orderItems = request.Items.Select(x =>
        {
            if (customerCoupon != null && customerCoupon.Coupon.CouponProducts.Any(cp => cp.ProductId == x.ProductId))
            {
                customerCoupon.Uses += 1;
                return new OrderItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = (x.Price * x.Quantity) * customerCoupon.Coupon.DiscountPercentage / 100
                };
            }
            return new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Price = x.Price,
                Discount = 0
            };
        }).ToList();

        var order = Order.Create(
            request.StatusId,
            request.CustomerId,
            request.AddressId,
            orderItems
        );

        await _orderRepository.InsertAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
