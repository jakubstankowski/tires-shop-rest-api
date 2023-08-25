using TyresShopAPI.Domain.Entities.Customers;

namespace TyresShopAPI.Domain.Entities.Cart
{
    public class CustomerCart : BaseModel
    {
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public int? DeliveryMethodId { get; set; }
    }
}
