using TyresShopAPI.Entities.Customers;
using TyresShopAPI.Models.Base;

namespace TyresShopAPI.Models;

public class Order : ModelBase
{
    public List<OrderTyre> OrderTyres { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
}