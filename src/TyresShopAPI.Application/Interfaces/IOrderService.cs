using TyresShopAPI.Domain.Models.Cart;
using TyresShopAPI.Domain.Models.Orders;

namespace TyresShopAPI.Application.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrder order);

        Task<List<OrderView>> GetOrdersByCustomerId(string customerId);

        decimal CalculateSubTotal(List<CartView> cartItems, decimal deliveryPrice);
    }
}
