using Microsoft.Extensions.Logging;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Domain.Entities.OrderAggregate;
using TyresShopAPI.Domain.Models.Cart;
using TyresShopAPI.Domain.Models.Orders;
using TyresShopAPI.Infrastructure.Persistance;

namespace TyresShopAPI.Application.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly ITyresService _tyresService;
        private readonly ICustomerCartService _customerCartService;
        private readonly IDeliveryMethodService _deliveryMethodService;
        private readonly IIdentityService _identityService;
        private ILogger<OrderService> _logger;

        public OrderService(Context context, ILogger<OrderService> logger, ITyresService tyresService, ICustomerCartService customerCartService, IDeliveryMethodService deliveryMethodService, IIdentityService identityService) : base(context)
        {
            _logger = logger;
            _tyresService = tyresService;
            _customerCartService = customerCartService;
            _deliveryMethodService = deliveryMethodService;
            _identityService = identityService;
        }

        public async Task CreateOrder(CreateOrder order)
        {
            List<int> cartItemsIds = new();

            await _identityService.IsCustomerExist(order.CustomerId);

            var deliveryMethod = await _deliveryMethodService.GetDeliveryMethodById(order.DeliveryMethodId);

            if (deliveryMethod is null)
            {
                throw new Exception("Delivery method is not exist");
            }

            var allCustomerCartItems = await _customerCartService.ReturnAllCustomerCartItems(order.CustomerId);

            if(!allCustomerCartItems.Any())
            {
                throw new Exception("Customer cart is empty");
            }

            var items = new List<OrderItem>();

            foreach (var item in allCustomerCartItems)
            {
                var tyreItem = await _tyresService.GetTyreBydId(item.TyreId);

                var orderItem = new OrderItem()
                {
                    TyreId = item.TyreId,
                    Price = tyreItem.Price,
                    Quantity = item.Quantity
                };

                items.Add(orderItem);
                cartItemsIds.Add(item.Id);
            }

            var subTotal = CalculateSubTotal(allCustomerCartItems, deliveryMethod.Price);

            var newOrder = new Order()
            {
                OrderItems = items,
                Subtotal = subTotal,
                CustomerId = order.CustomerId,
            };

            _context.Orders.Add(newOrder);

            _logger.LogInformation("Success add order");

            await _context.SaveChangesAsync();

            await _customerCartService.RemoveCartItemByIds(cartItemsIds);
        }

        private static decimal CalculateSubTotal(List<CartView> cartItems, decimal deliveryPrice)
        {
            return cartItems.Sum(x => x.TotalValue) + deliveryPrice;
        }

    }
}
