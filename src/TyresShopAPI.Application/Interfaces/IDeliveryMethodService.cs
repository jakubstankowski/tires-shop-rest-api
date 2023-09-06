using TyresShopAPI.Domain.Models.DeliveryMethod;

namespace TyresShopAPI.Application.Interfaces
{
    public interface IDeliveryMethodService
    {
        public Task<DeliveryMethodView?> GetDeliveryMethodById(int deliveryMethodId);
    }
}
