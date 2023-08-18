using TyresShopAPI.Domain.Enums;

namespace TyresShopAPI.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerId { get; set; }
        public decimal SubTotal { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public decimal TotalOrder
        {
            get { return SubTotal + (OrderItems.Sum(item => item.Price)); }
        }       
    }
}