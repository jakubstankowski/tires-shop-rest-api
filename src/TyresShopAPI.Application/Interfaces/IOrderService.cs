using TyresShopAPI.Domain.Models.Orders;

namespace TyresShopAPI.Application.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrder order);
    }
}
