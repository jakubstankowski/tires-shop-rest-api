namespace TyresShopAPI.Domain.Models.Cart
{
    public class CreateCartItem
    {
        public int CartId { get; set; }

        public IEnumerable<CartItems> Items { get; set; }
    }
}
