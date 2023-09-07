using TyresShopAPI.Domain.Models.Orders;

namespace TyresShopAPI.Application.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrder order);

        Task<List<OrderView>> GetOrdersByCustomerId(string customerId);
    }
}
