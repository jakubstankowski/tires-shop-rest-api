using TyresShopAPI.Domain.Enums;

namespace TyresShopAPI.Domain.Entities.OrderAggregate
{
    public class Order
    {
        public string BuyerEmail { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; } = string.Empty;
    }
}
