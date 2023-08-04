using TyresShopAPI.Models.Base;

namespace TyresShopAPI.Models;

public class Manufacturer : ModelBase
{
    public string Name { get; set; }
    public string Country { get; set; }

    public List<Tyre> Tyres { get; set; }

    public Manufacturer(string name, string country)
    {
        Name = name;
        Country = country;
        Tyres = new List<Tyre>();
    }
}