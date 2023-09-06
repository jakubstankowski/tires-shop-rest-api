using TyresShopAPI.Domain.Entities.Customers;
using TyresShopAPI.Domain.Enums;

namespace TyresShopAPI.Domain.Entities.OrderAggregate
{
    public class Order : BaseModel
    {
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public ICollection<OrderDelivery> OrderDeliveries { get; set; } = new List<OrderDelivery>();
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
    }
}
