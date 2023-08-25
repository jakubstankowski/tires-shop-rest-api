namespace TyresShopAPI.Domain.Entities.OrderAggregate
{
    public class OrderDelivery : BaseModel
    {
        public Order Orders { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

    }
}
