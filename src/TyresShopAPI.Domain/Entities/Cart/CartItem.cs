namespace TyresShopAPI.Domain.Entities.Cart
{
    public class CartItem : BaseModel
    {
        public int CartId { get; set; }

        public int TyreId { get; set; }

        public int Quantity { get; set; }
    }
}
