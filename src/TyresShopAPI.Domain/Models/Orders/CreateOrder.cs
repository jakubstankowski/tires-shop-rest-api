namespace TyresShopAPI.Domain.Models.Orders
{
    public class CreateOrder
    {
        public string CustomerId { get; set; }
        public int DeliveryMethodId { get; set; }
    }
}
