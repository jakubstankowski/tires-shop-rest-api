using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Domain.Entities.OrderAggregate;
using TyresShopAPI.Domain.Enums;
using TyresShopAPI.Domain.Models.DeliveryMethod;
using TyresShopAPI.Domain.Models.Orders;
using TyresShopAPI.Infrastructure.Persistance;

namespace TyresShopAPI.Application.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly TyresService _tyresService;
        private readonly CustomerCartService _customerCartService;
        private readonly DeliveryMethodService _deliveryMethodService;

        public OrderService(Context context, TyresService tyresService, CustomerCartService customerCartService, DeliveryMethodService deliveryMethodService) : base(context)
        {
            _tyresService = tyresService;
            _customerCartService = customerCartService;
            _deliveryMethodService = deliveryMethodService;
        }

        public async Task CreateOrder(CreateOrder order)
        {
            var allCustomerCartItems = await _customerCartService.ReturnAllCustomerCartItems(order.CustomerId);


            var deliveryMethod = await _deliveryMethodService.GetDeliveryMethodById(order.DeliveryMethodId);

            if (deliveryMethod is null)
            {
                throw new Exception("Delivery method is not exist");
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
            }

            var subTotal = allCustomerCartItems.Sum(x => x.TotalValue) + deliveryMethod.Price;

            var newOrder = new Order()
            {
                OrderItems = items,
                Subtotal = subTotal,
                CustomerId = order.CustomerId,
                PaymentIntentId = null,
                Status = OrderStatus.Pending
            };

            _context.Orders.Add(newOrder);

            await _context.SaveChangesAsync();
        }
        
    }
}
