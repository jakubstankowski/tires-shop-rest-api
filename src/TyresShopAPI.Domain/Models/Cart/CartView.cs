namespace TyresShopAPI.Domain.Models.Cart
{
    public class CartView
    {
        public int TyreId { get; set; }

        public decimal TotalValue { get; set; }

        public int Quantity { get; set; }
    }
}
