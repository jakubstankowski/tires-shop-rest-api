using TyresShopAPI.Domain.Entities;

namespace TyresShopAPI.Domain.Models.Cart
{
    public class CartItemCreate : BaseModel
    {
        public int CustomerId { get; set; }

        public int TyreId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalValue { get; set; }
    }
}
