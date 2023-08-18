namespace TyresShopAPI.Domain.Entities.Order
{
    public class BasketItem : BaseModel
    {
        public Tyre Tyre { get; set; }
        public int TyreId { get; set; }
        public int Quantity { get; set; }
    }
}
