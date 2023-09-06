using TyresShopAPI.Domain.Entities;

namespace TyresShopAPI.Domain.Models.Cart
{
    public class CartView : BaseModel
    {
        public int TyreId { get; set; }

        public decimal TotalValue { get; set; }

        public int Quantity { get; set; }
    }
}
