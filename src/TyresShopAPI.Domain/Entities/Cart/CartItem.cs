using System.ComponentModel.DataAnnotations;

namespace TyresShopAPI.Domain.Entities.Cart
{
    public class CartItem : BaseModel
    {
        public int TyreId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalValue { get; set; }

        public CustomerCart CustomerCart { get; set; }

        public int CustomerCartId { get; set; }

    }
}
