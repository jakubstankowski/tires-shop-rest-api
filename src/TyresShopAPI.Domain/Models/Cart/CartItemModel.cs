using TyresShopAPI.Domain.Entities;

namespace TyresShopAPI.Domain.Models.Cart
{
    public class CartItemModel
    {
        public string CustomerId { get; set; } = null!;

        public int TyreId { get; set; }

        public int Quantity { get; set; }
    }
}
