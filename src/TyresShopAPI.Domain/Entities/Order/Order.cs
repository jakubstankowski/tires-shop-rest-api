using TyresShopAPI.Domain.Entities.Customers;
using TyresShopAPI.Domain.Enums;

namespace TyresShopAPI.Domain.Entities.Order
{
    public class Order : BaseModel
    {
        public int CustomerId { get; set; }

        public IEnumerable<BasketItem> BasketItems { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public decimal? SubTotal { get; set; }

        public void CalculateSubTotal()
        {
            if (BasketItems.Count() <= 0)
            {
                SubTotal = null;
            }

            SubTotal = BasketItems.Sum(x => x.Tyre.Price * x.Quantity);
        }

    }

}
