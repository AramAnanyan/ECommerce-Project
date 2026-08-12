using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.UseCases.Orders.Commands.Create;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository,IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        CouponCustomer customerCoupon = null;
        if (!string.IsNullOrWhiteSpace(request.CouponCode))
        {
            customerCoupon = await _customerRepository.GetCustomerCouponAsync(request.CustomerId, request.CouponCode, cancellationToken);
            if (customerCoupon == null || !customerCoupon.IsValid)
                throw new Exception("Coupon is not valid");
        }
        var productIds = request.Items.Select(x => x.ProductId).Distinct();

        var productDict = new Dictionary<int, Product>();
        foreach (var id in productIds)
        {
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (product == null)
                throw new Exception($"Product with id {id} was not found");
            productDict[id] = product;
        }

        var orderItems = request.Items.Select(x =>
        {
            var product = _productRepository.GetByIdAsync(x.ProductId,cancellationToken);
            if (customerCoupon != null && customerCoupon.Coupon.CouponProducts.Any(cp => cp.ProductId == x.ProductId))
            {
                customerCoupon.Uses += 1;
                return new OrderItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Price = productDict[x.ProductId].Price,
                    Discount = (productDict[x.ProductId].Price * x.Quantity) * customerCoupon.Coupon.DiscountPercentage / 100
                };
            }
            return new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Price = productDict[x.ProductId].Price,
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
