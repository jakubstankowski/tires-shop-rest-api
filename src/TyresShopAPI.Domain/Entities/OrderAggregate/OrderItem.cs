namespace TyresShopAPI.Domain.Entities.OrderAggregate
{
    public class OrderItem : BaseModel
    {

        public int TyreId { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
