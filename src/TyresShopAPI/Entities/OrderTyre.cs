using TyresShopAPI.Models.Base;

namespace TyresShopAPI.Models;

public class OrderTyre : ModelBase
{
    public Tyre Tyre{ get; set; }
    public int TyreId { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }

    public decimal Quantity { get; set; }
}