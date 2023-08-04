using TyresShopAPI.Models.Base;

namespace TyresShopAPI.Models;

public class Manufacturer : ModelBase
{
    public string Name { get; set; }
    public string Country { get; set; }
    public List<Tyre> Tyres { get; set; }
}