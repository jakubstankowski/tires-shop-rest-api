namespace TyresShopAPI.Domain.Models.Orders
{
    public class OrderView
    {
        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public IEnumerable<OrderItemView> Items { get; set; } = new List<OrderItemView>();

        public decimal Subtotal { get; set; }
    }
}
