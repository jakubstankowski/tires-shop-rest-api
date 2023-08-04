using TyresShopAPI.Models.Base;
using TyresShopAPI.Models.Enum;

namespace TyresShopAPI.Models
{
    public class Tyre : ModelBase
    {
        public string Model { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public decimal Price { get; set; }
        public int ProductionYear { get; set; }
        public int SizeWidth { get; set; }
        public int SizeProfile { get; set; }
        public int SizeDiameter { get; set; }
        public TyreType TyreType { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        
        public List<OrderTyre> OrderTyres { get; set; }
    }
}