namespace TyresShopAPI.Domain.Entities.Cart
{
    public class CustomerCart : BaseModel
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public int? DeliveryMethodId { get; set; }
    }
}
