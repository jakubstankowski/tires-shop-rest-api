namespace TyresShopAPI.Domain.Models.Orders
{
    public class CreateOrder
    {
        public string CustomerId { get; set; } = null!;
        public int DeliveryMethodId { get; set; }
    }
}
