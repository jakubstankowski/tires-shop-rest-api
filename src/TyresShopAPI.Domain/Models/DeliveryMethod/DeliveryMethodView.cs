using TyresShopAPI.Domain.Entities;

namespace TyresShopAPI.Domain.Models.DeliveryMethod
{
    public class DeliveryMethodView : BaseModel
    {
        public decimal Price { get; set; }

        public string Name { get; set; } = string.Empty;

        public string DeliveryTime { get; set; } = string.Empty;
    }
}
