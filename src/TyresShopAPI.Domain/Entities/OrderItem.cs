namespace TyresShopAPI.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int TyreId { get; set; }
        public decimal Price { get; set; }
    }
}
