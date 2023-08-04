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

        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public Tyre(string model, decimal price, int productionYear, int sizeProfile, int sizeWidth, int sizeDiameter, TyreType tyreType, Manufacturer manufacturer)
        {
            Model = model;
            Price = price;
            ProductionYear = productionYear;
            SizeWidth = sizeWidth;
            SizeProfile = sizeProfile;
            SizeDiameter = sizeDiameter;
            TyreType = tyreType;
            Manufacturer = manufacturer;
            ManufacturerId = manufacturer.Id;
        }
    }
}
