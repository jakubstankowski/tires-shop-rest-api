namespace TyresShopAPI.Domain.Models.Orders
{
    public class OrderItemView
    {
        public string Producer { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
