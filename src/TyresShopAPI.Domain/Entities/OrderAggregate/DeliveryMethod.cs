namespace TyresShopAPI.Domain.Entities.OrderAggregate
{
    public class DeliveryMethod : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string DeliveryTime { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
